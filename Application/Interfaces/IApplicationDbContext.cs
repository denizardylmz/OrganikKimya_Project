using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Domain.Entities.Item> Items { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);

}