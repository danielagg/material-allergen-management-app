using MAM.Materials.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MAM.Allergens.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection RegisterMaterialsAssemblyDependencyInjections(this IServiceCollection services)
    {
        services.AddDbContext<MaterialsDbContext>(x => x.UseSqlite("DataSource=app.db", x => {
            x.MigrationsAssembly("MAM.Materials");
            x.MigrationsHistoryTable("__MaterialsEFMigrationsHistory");
        }));

        return services;
    }
}