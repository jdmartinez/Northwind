﻿using Northwind.Shared.Domain.Interfaces;
using Northwind.Shared.Domain.ValueObjects;

namespace Northwind.Shared.Domain.Entities;

public class Customer : IEntity
{
    public string CustomerId { get; set; } = default!;

    public string CompanyName { get; set; } = default!;

    public string? ContactName { get; set; } = default!;

    public string? ContactTitle { get; set; } = default!;

    public string? Address { get; set; } = default!;

    public string? City { get; set; } = default!;

    public string? Region { get; set; } = default!;

    public string? PostalCode { get; set; } = default!;

    public string? Country { get; set; } = default!;

    public string? Phone { get; set; } = default!;

    public string? Fax { get; set; } = default!;

    public ICollection<Order> Orders { get; private set; } = new HashSet<Order>();
}