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
            eb.Property(p => p.InternalCode).HasMaxLength(20).IsRequired();
            eb.Property(p =>p.Name).HasMaxLength(50);
            eb.Property(p =>p.Description).HasMaxLength(60);

        });
    }
}
