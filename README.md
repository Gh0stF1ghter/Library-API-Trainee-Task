# Library API Trainee  Task

This is a basic api used to provide information about books(name, description, author, genres, ISBN)

## Before first launch
### Update Database using Migrations:
via .NET CLI:

    dotnet ef database update

via Package Manager:

    Update-Database

## Technologies

### The project was developed using ASP.Net Core, Entity Framework with MS SQL Server database and Microsoft Identity platform

## Architecure & Patterns
### The project was developed according to Clean Archtecture principles and Service/Repository patterns
#### Core:

 * Interfaces for repositories and services
 * Models for database
 * Unit of work interface

#### Data:

* Database context
* Migrations
* Tables' Configurations
* Repositories
* Unit of work

#### Service:

*  Services for access to Data layer

#### API:

* Controllers
* Mapping Profile
* Validators
* Authentication
* Resources for saving & representing data



