using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Category : IEntity
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string Description { get; set; } = null!;

    public byte[] Picture { get; set; } = null!;

    public ICollection<Product> Products { get; private set; } = new HashSet<Product>();

}