# Configuration, Operations, and Data Loading Strategies

Overview of Entity Framework Core (EF Core), an open-source ORM for .NET, which allows developers to work with databases using .NET objects.

## Topics
- Project configured for SQL Server using the Command Line Interface (CLI).
- EnsureDeleted and EnsureCreated to manage the database lifecycle during development.
- Solutions to handle gaps in EnsureCreated when using multiple DbContexts.
- Implementation of health checks to monitor database connectivity and status.
- Efficiently managing the database connection state.
- Using ExecuteSql commands to execute raw SQL queries within EF Core.
- Practices to prevent SQL Injection attacks in EF Core applications.
- Methods to detect pending migrations that need to be applied to the database.
- Forcing a migration.
- Retrieving all migrations defined in the application.
- Retrieving migrations that have been applied to the database.
- Generating SQL scripts for creating the data model.
- Overview of different data loading strategies in EF Core.
- Querying data using eager loading.
- Querying data using explicit loading.
- Querying data using lazy loading.


## Migration

- Create a new migration on FundamentosEF.Data
 
```bash
Add-Migration initial -context FundamentosEF.Data.ApplicationContextMigrations
```
- Remove comment from entity Cities on the migration file

'''bash 
Add-Migration Cities -context FundamentosEF.Data.ApplicationContextCity
``` 


