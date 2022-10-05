using Microsoft.Extensions.Configuration;

namespace Infrastructure.Common.GetConnectionString;

public class Configurations
{
    public static string GetConnectionString(string name)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../WebAPI"))
            .AddJsonFile("appsettings.json");

        var configuration = builder.Build();

        return configuration.GetConnectionString(name);
    }
}