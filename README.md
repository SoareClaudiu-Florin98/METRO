# API

## Run docker compose 
### (Make sure you have 1,5 GB available for the Microsoft SQL Server Image)



## Database

## Adding a new migration
cd METROAssignment.Database

dotnet ef migrations add AddInitialMigration --startup-project ../METROAssignment.API/METROAssignment.API.csproj --context MetroDbContext

More information: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations 

## Running a migration

dotnet ef database update --startup-project ../METROAssignment.API/METROAssignment.API.csproj --context MetroDbContext -- --environment Development

## Removing a migration

dotnet ef migrations remove --startup-project ../METROAssignment.API/METROAssignment.API.csproj --context MetroDbContext

## To unapply and remove last migration:

dotnet ef migrations remove --force
or
PM> Remove-Migration -Force
To remove last migration:

dotnet ef migrations remove
or
PM> Remove-Migration
