set -ex
ASPNETCORE_ENVIRONMENT=Development dotnet ef migrations remove $1 -c MAM.Allergens.Infrastructure.AllergensDbContext --project ../MAM.Allergens.csproj --startup-project ../../MAM.API