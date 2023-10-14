set -ex
ASPNETCORE_ENVIRONMENT=Development dotnet ef migrations remove $1 -c MAM.Inventory.Infrastructure.InventoryDbContext --project ../MAM.Inventory.csproj --startup-project ../../MAM.API