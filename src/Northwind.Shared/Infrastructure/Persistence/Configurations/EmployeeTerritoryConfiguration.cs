﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Northwind.Shared.Domain.Entities;

namespace Northwind.Shared.Infrastructure.Persistence.Configurations;

public class EmployeeTerritoryConfiguration : IEntityTypeConfiguration<EmployeeTerritory>
{
    public void Configure(EntityTypeBuilder<EmployeeTerritory> builder)
    {
        builder.ToTable("EmployeeTerritories");

        builder.HasKey(e => new { e.EmployeeId, e.TerritoryId })
            .IsClustered(false);

        builder.Property(e => e.EmployeeId).HasColumnName("EmployeeID");

        builder.Property(e => e.TerritoryId)
            .HasColumnName("TerritoryID")
            .HasMaxLength(20);

        builder.HasOne(d => d.Employee)
            .WithMany(p => p.EmployeeTerritories)
            .HasForeignKey(d => d.EmployeeId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_EmployeeTerritories_Employees");

        builder.HasOne(d => d.Territory)
            .WithMany(p => p.EmployeeTerritories)
            .HasForeignKey(d => d.TerritoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_EmployeeTerritories_Territories");

    }
}
