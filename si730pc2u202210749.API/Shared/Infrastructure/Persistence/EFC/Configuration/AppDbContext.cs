using si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using si730pc2u202210749.API.Logistics.Domain.Model.Aggregates;

namespace si730pc2u202210749.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }
    // Sirve para usarlo en el Service y poder crear queries como findByTripId en vez de Id
    public DbSet<Inventory> Inventories { get; set; }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Logistics Context
        
        //Inventory Table
        // Adds the primary key
        builder.Entity<Inventory>().HasKey(i => i.Id);
        // Adds the primary key with autoincrement
        builder.Entity<Inventory>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        // Adds constraints to the table
        builder.Entity<Inventory>().OwnsOne(i => i.ProductId,
            p =>
            {
                p.WithOwner().HasForeignKey("id");
                p.Property(r => r.ProductId).HasColumnName("ProductId");
            });
        
        builder.Entity<Inventory>().OwnsOne(i => i.WarehouseId,
            w =>
            {
                w.WithOwner().HasForeignKey("id");
                w.Property(a => a.WarehouseId).HasColumnName("WarehouseId");
            });
        
        builder.Entity<Inventory>().OwnsOne(i => i.MinimumStock,
            m =>
            {
                m.WithOwner().HasForeignKey("id");
                m.Property(n => n.MinimumStock).HasColumnName("MinimumStock");
            });
        
        builder.Entity<Inventory>().OwnsOne(i => i.CurrentStock,
            c =>
            {
                c.WithOwner().HasForeignKey("id");
                c.Property(u => u.CurrentStock).HasColumnName("CurrentStock");
            });

        builder.Entity<Inventory>().Property(i => i.Status).HasConversion<string>();
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}