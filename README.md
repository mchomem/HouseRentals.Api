# HouseRentals

HouseRentals is a web api rest with minimal functionality to manage house rentals.
This project was created to be used together with AWS cloud services.

# How to Use

First, have a running Sql Server 2019 instance available.
Configure the connection string in `appsettings.json` in the `HouseRentals.Api` project to the settings of your Sql Server instance.
Run the commands in the Db Installation section to generate the database.
Optionally, run the sql scripts to generate fake Tenant and House.

## DB Installation

This project uses Entity Framework Core to manage the database. To install the database, you need to run the some commands in the Package Manager Console
in the root folder of the project, run the following commands:

```bash
Add-Migration InitialCreate -Context AppDbContext

Update-Database -Context AppDbContext
```

Important: the `add-migration` command should only be run if there is no Migrations directory in the `HouseRentals.Database` project.

## DB Entity Relationship Diagram

![Entity relationship](/Docs/Images/er.png)

There are three entities, showing that this model is simple.
