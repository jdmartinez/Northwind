using System.ComponentModel.DataAnnotations.Schema;

namespace Northwind.Shared.Domain.ValueObjects;

public class Address : ValueObject
{
    [Column("Address")]
    public string? Street { get; set; } = default!;

    [Column("City")]
    public string? City { get; set; } = default!;

    [Column("Country")]
    public string? Country { get; set; } = default!;

    [Column("PostalCode")]
    public string? PostalCode { get; set; } = default!;

    public Address() 
    { }
   
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Street;
        yield return City;
        yield return Country;
        yield return PostalCode;
    }
}
