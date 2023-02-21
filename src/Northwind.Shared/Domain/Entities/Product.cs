using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Product : IEntity
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? SupplierId { get; set; }

    public int? CategoryId { get; set; }

    public string QuantityPerUnit { get; set; } = null!;

    public decimal? UnitPrice { get; set; }


    public short? UnitsInStock { get; set; }

    public short? UnitsOnOrder { get; set; }

    public short? ReorderLevel { get; set; }

    public bool Discontinued { get; set; }

    public Category Category { get; set; } = null!;

    public Supplier Supplier { get; set; } = null!;

    public ICollection<OrderDetail> OrderDetails { get; private set; } = new HashSet<OrderDetail>();
}