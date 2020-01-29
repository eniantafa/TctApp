# TctApp
This is an web application developed along with Tirana Center of Technology .Net Core Course 


MVC App using ASP.NET Core, Entity Framework Core and Code First Pattern##

Technologies used: • ASP.NET Core • Entity Framework Core • Entity Framework Migrations – Code First •Razor Engine •Dependency Injection •LINQ •Repository Pattern

1.Installing .NET Core To install .NET Core (prefered 2.1 version) please follow the steps on the official web site https://dotnet.microsoft.com/download/dotnet-core

2.Opening project -Open the solution in VS 2017/2019

-Open Package Manager Console on the project by going to: Tools > Nuget Package Manager > Package Manager Console

3.-On the start up class modify the database connection string (connection) to reflect your database environment

4.-Run the following commands (they will create the database schema on your database environment):

dotnet ef migrations add FirstMigration

dotnet ef database update
