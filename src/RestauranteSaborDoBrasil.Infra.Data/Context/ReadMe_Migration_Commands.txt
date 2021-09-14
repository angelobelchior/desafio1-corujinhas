//run the commands below in the RestauranteSaborDoBrasil.Api project (when running on DotNet CLI Shell)

==> command to add a new migration
Shell: dotnet ef migrations add <migration-name> -c WritingDbContext
PMC: Add-Migration <migration-name> -Context WritingDbContext -Project RestauranteSaborDoBrasil.Infra.Data -StartupProject RestauranteSaborDoBrasil.Api

==> command to remove the last migration created
Shell: dotnet ef migrations remove -c WritingDbContext
PMC: Remove-Migration -Context WritingDbContext -Project RestauranteSaborDoBrasil.Infra.Data -StartupProject RestauranteSaborDoBrasil.Api

==> command to update the database with all pending migrations
Shell: dotnet ef database update -c WritingDbContext -s RestauranteSaborDoBrasil.Api
PMC: Update-Database -Context WritingDbContext -Project RestauranteSaborDoBrasil.Infra.Data -StartupProject RestauranteSaborDoBrasil.Api

==> command to remove all migrations from database but not the files from project
Shell: dotnet ef database update 0 -c WritingDbContext
PMC: Update-Database -Migration 0 -Context WritingDbContext

==> command to undo to a specific migration
Shell: dotnet ef database update <migration-name> -c WritingDbContext -s RestauranteSaborDoBrasil.Api
PMC: Update-Database <migration-name> -Context WritingDbContext -Project RestauranteSaborDoBrasil.Infra.Data -StartupProject RestauranteSaborDoBrasil.Api

==> command to generate the SQL Script DB for ALL database
Shell: dotnet ef migrations script -o ./bin/hubMigrations.sql -c WritingDbContext 
PMC: Script-Migration <migration-name>

==> command to generate the SQL Script DB for ALL database with pre-validations
Shell/PMC: dotnet ef migrations script -o ./bin/hubMigrations.sql -c WritingDbContext --idempotent

==> Command to install EF Core 5.x.x Migration CLI Tool
dotnet tool install --global dotnet-ef

==> Command to update EF Core 5.x.x Migration CLI Tool with the latest version
dotnet tool uninstall --global dotnet-ef
dotnet tool install --global dotnet-ef

==> Command to list all dotnet Tools installed
dotnet tool list

==> command to upgrade a specific database without having to change the environment
PMC: $env:ASPNETCORE_ENVIRONMENT="DIT"