using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Region : IEntity
{
    public int RegionId { get; set; }

    public string RegionDescription { get; set; } = null!;

    public ICollection<Territory> Territories { get; private set; } = new HashSet<Territory>();
}