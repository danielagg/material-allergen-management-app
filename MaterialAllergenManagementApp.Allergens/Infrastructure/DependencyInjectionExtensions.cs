using MaterialAllergenManagementApp.Allergens;
using Microsoft.Extensions.DependencyInjection;

namespace MaterialAllergenManagementApp.Allergens.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection RegisterDependencyInjections(this IServiceCollection services)
    {
        services.AddScoped<IMaterialAllergenApplicationService, MaterialAllergenApplicationService>();
        return services;
    }
}