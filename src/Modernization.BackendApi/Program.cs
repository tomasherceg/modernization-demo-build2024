using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modernization.BackendApi;
using Modernization.BackendApi.Data;
using Modernization.BackendClient.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB"));
});

var app = builder.Build();

// map operations
app.MapGet("/products", async (ShopDbContext dbContext, int skip = 0, int take = 20) =>
{
    return new PagedResponse<ProductModel>()
    {
        Results = await dbContext.Products
            .Select(p => new ProductModel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                ImageUrl = p.ImageUrl
            })
            .OrderBy(p => p.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync(),
        TotalRecordCount = await dbContext.Products.CountAsync()
    };
});

app.MapGet("/products/{id}", async (ShopDbContext dbContext, Guid id) =>
{
    return await dbContext.Products
        .Select(p => new ProductModel()
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
            ImageUrl = p.ImageUrl
        })
        .SingleOrDefaultAsync(p => p.Id == id);
});

app.MapGet("/products/{id}/price/{currency}", async (ShopDbContext dbContext, Guid id, string currency = "USD") => {
    var product = await dbContext.Products
        .Include(p => p.Prices)
        .SingleAsync(p => p.Id == id);

    var productPrice = product.Prices
        .FirstOrDefault(p => p.CurrencyCode == currency);

    return productPrice?.Price;
});

app.MapPut("/products/{id}/price/{currency}", async (ShopDbContext dbContext, Guid id, string currency, [param: FromBody] decimal newPrice) =>
{
    var product = await dbContext.Products
        .Include(p => p.Prices)
        .SingleAsync(p => p.Id == id);
    if (product.Prices.FirstOrDefault(p => p.CurrencyCode == currency) is not { } productPrice)
    {
        productPrice = new ProductPrice()
        {
            CurrencyCode = currency,
            Price = newPrice
        };
        product.Prices.Add(productPrice);
    }
    productPrice.Price = newPrice;
    await dbContext.SaveChangesAsync();
});

// seed database
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
    if (await dbContext.Database.EnsureCreatedAsync())
    {
        await Seeder.Seed(dbContext);
    }
}

app.Run();
