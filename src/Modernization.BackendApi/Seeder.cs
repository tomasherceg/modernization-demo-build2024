using Bogus;
using Modernization.BackendApi.Data;

namespace Modernization.BackendApi;

public class Seeder
{
    public static async Task Seed(ShopDbContext context)
    {
        var otherCurrencies = new[] { "EUR", "JPY", "GBP" };

        var productsFaker = new Faker<Product>()
            .RuleFor(p => p.Id, f => f.Random.Guid())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.ImageUrl, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Prices, f => 
                new[]
                {
                    new ProductPrice() { CurrencyCode = "USD", Price = f.Random.Decimal(0.1m, 10000m) }
                }
                .Concat(
                    f.PickRandom(otherCurrencies, f.Random.Int(1, otherCurrencies.Length))
                    .Select(c => new ProductPrice()
                    {
                        CurrencyCode = c,
                        Price = f.Random.Decimal(0.1m, 10000m)
                    }))
            .ToList());

        context.Products.AddRange(productsFaker.Generate(100));
        await context.SaveChangesAsync();
    }
}