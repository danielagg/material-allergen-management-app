using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace MaterialAllergenManagementApp.Allergens.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection RegisterDependencyInjections(this IServiceCollection services)
    {
        services.AddDbContext<AllergensDbContext>(x => x.UseSqlite("DataSource=app.db", x => {
            x.MigrationsAssembly("MaterialAllergenManagementApp.Allergens");
            x.MigrationsHistoryTable("__AllergensEFMigrationsHistory");
        }));

        services.AddScoped<IMaterialAllergenApplicationService, MaterialAllergenApplicationService>();
        return services;
    }
}