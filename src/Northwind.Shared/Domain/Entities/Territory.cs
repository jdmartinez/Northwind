using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Territory : IEntity
{
    public string TerritoryId { get; set; } = null!;

    public string TerritoryDescription { get; set; } = null!;

    public int RegionId { get; set; }

    public Region Region { get; set; } = null!;

    public ICollection<EmployeeTerritory> EmployeeTerritories { get; private set; } = new HashSet<EmployeeTerritory>();
}