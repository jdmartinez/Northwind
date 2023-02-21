using Northwind.Shared.Domain.Interfaces;

namespace Northwind.Shared.Domain.Entities;

public class Employee : IEntity
{
    public int EmployeeId { get; set; }

    public string UserId { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string TitleOfCourtesy { get; set; } = null!;

    public DateTime? BirthDate { get; set; }

    public DateTime? HireDate { get; set; }

    public string Address { get; set; } = null!;

    public string City { get; set; } = null!;

    public string Region { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string HomePhone { get; set; } = null!;

    public string Extension { get; set; } = null!;

    public byte[] Photo { get; set; } = null!;

    public string Notes { get; set; } = null!;

    public int? ReportsTo { get; set; } = null!;

    public string PhotoPath { get; set; } = null!;

    public Employee Manager { get; set; } = null!;

    public ICollection<EmployeeTerritory> EmployeeTerritories { get; private set; } = new HashSet<EmployeeTerritory>();

    public ICollection<Employee> DirectReports { get; private set; } = new HashSet<Employee>();

    public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();

}