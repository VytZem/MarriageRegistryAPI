# MarriageRegistryAPI

MarriageRegistryAPI is application to enter marriage records and save them in database also manage marriage list.

Application configuration: 

1. Application uses Sql server database, before using application necessary:
  - Provide connectionstring in appsettings.json file with server name and other settings. Examples: 
    - "DefaultConnection": "Server=[YourSqlServerNameHere];Database=CodeChallengeDb;Trusted_Connection=True;MultipleActiveResultSets=True;",
    - "DefaultConnection": "Server=[YourSqlServerNameHere];Database=CodeChallengeDB;User Id=[YourUserIdHere];Password=[YourPasswordHere];"
2. After database connection configuration, create database and its structure with provided migrations: 
   - Open "NuGet Package Console" from Tools --> NuGet Package Manager --> Package  Manager Console;
   - Enter command "update-database";
        
3. Application testing is possible via Swagger. 
