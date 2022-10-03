using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Configurations;

public static class ItemConfigurations
{
    public static void ConfigureItem(this ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Item>()
            .Property(p => p.Description).HasMaxLength(50).IsRequired(required:false);
        
        modelBuilder.Entity<Item>()
            .Property(p => p.SerialNumber).HasMaxLength(10).IsRequired();
        
        modelBuilder.Entity<Item>()
            .Property(p => p.StockGroupNumber).HasMaxLength(10).IsRequired();

    }
}