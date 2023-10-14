set -ex
ASPNETCORE_ENVIRONMENT=Development dotnet ef migrations remove $1 -c MAM.Materials.Infrastructure.MaterialsDbContext --project ../MAM.Materials.csproj --startup-project ../../MAM.API