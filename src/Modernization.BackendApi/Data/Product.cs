namespace Modernization.BackendApi.Data;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ImageUrl { get; set; }

    public List<ProductPrice> Prices { get; set; } = new();
}