# MyBibsAPI
simple api designed tool for building football teams


## Migrations!
## Create Migration

windows: cmd is `dotnet-ef migrations add <ModelName> --startup-project --context BoulderContent`
linux/bash: cmd is `dotnet ef migrations add <MigrationName> --startup-project boulder.api.csproj --context BoulderContext`

## Update to revert Migration

To revert previous migration from db cmd is `dotnet-ef database update <Previous migration name> --startup-project ..\Bibs.API\Bibs.API.csproj --context AppDbContext -v`

## Remove Migration

To remove previous migration cmd is `dotnet-ef migrations remove --startup-project ..\Bibs.API\Bibs.API.csproj --context AppDbContext`