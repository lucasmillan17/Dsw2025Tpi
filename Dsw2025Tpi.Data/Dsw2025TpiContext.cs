using Dsw2025Tpi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dsw2025Tpi.Data;

public class Dsw2025TpiContext: DbContext
{
    public Dsw2025TpiContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>(eb => {
            eb.ToTable("Products");
            eb.Property(p => p.Sku).IsRequired();
            eb.Property(p => p.InternalCode).HasMaxLength(20);
            eb.Property(p => p.Name).HasMaxLength(50);
            eb.Property(p => p.Description).HasMaxLength(60);
            eb.Property(p => p.CurrentUnitPrice).HasPrecision(15, 2);
            eb.HasKey(p => p.Id);
        });
        modelBuilder.Entity<Order>(eb => {
            eb.ToTable("Orders");
            eb.Property(p => p.ShippingAddress).HasMaxLength(60);
            eb.Property(p => p.BillingAddress).HasMaxLength(60);
            eb.Property(p => p.Notes).HasMaxLength(60);
            eb.HasKey(p => p.Id);
        });
        modelBuilder.Entity<Customer>(eb =>
        {
            eb.ToTable("Customers");
            eb.HasKey(p => p.Id);
        });
        modelBuilder.Entity<OrderItem>(eb => {
            eb.ToTable("OrderItems");
            eb.Property(p => p.UnitPrice).HasPrecision(15, 2);
            eb.HasKey(p => p.Id);
        });
    }
}
