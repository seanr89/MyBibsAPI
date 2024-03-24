# MyBibsAPI
simple api designed tool for building football teams


## Migrations!
## Create Migration

windows: cmd is `dotnet-ef migrations add <ModelName> --startup-project --context BoulderContent`
linux/bash: cmd is `dotnet ef migrations add <MigrationName> --startup-project ./BibsAPI.csproj --context AppDbContext`


## Update to revert Migration

To revert previous migration from db cmd is `dotnet-ef database update <Previous migration name> --startup-project MyBipsAPI.csproj --context AppDbContext -v`

## Remove Migration

To remove previous migration cmd is `dotnet-ef migrations remove --startup-project MyBipsAPI.csproj --context AppDbContext`