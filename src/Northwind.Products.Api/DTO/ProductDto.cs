namespace Northwind.Products.Api.DTO;

public class ProductDto
{
    public int Id { get; set; }

    public string Name { get; set; } = default!;

    public decimal UnitPrice { get; set; }

    public int AvailableStock { get; set; }

    public int ReservedStock { get; set; }
}
