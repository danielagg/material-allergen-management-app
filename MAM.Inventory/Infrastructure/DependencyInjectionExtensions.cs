using MAM.Inventory.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MAM.Inventory.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection RegisterInventoryAssemblyDependencyInjections(this IServiceCollection services)
    {
        services.AddDbContext<InventoryDbContext>(x => x.UseSqlite("DataSource=app.db", x => {
            x.MigrationsAssembly("MAM.Inventory");
            x.MigrationsHistoryTable("__InventoryEFMigrationsHistory");
        }));

        return services;
    }
}