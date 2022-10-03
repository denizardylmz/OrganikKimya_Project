using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence;

public class DesignTimeContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var serviceVersion = new MySqlServerVersion(new Version(8, 0, 30));
        var connectionString = "Server=localhost;Port=3306;Database=OrganikKimyaInventory;Uid=root;Pwd=Deneme123;";
        
        DbContextOptionsBuilder<ApplicationDbContext> dbContextOptionsBuilder = new();
        dbContextOptionsBuilder.UseMySql(connectionString, serviceVersion);
        return new(dbContextOptionsBuilder.Options);
    }
}