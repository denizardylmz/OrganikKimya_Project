using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class IdentityAppDb : IdentityDbContext<AppUser, AppRole, int>, IApplicationDbContext
{
    
    public IdentityAppDb(DbContextOptions<IdentityAppDb> options) : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureItem();
        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }

}
