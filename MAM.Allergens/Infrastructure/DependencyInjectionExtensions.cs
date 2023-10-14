using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection RegisterAllergenAssemblyDependencyInjections(this IServiceCollection services)
    {
        services.AddDbContext<AllergensDbContext>(x => x.UseSqlite("DataSource=app.db", x => {
            x.MigrationsAssembly("MAM.Allergens");
            x.MigrationsHistoryTable("__AllergensEFMigrationsHistory");
        }));

        return services;
    }
}