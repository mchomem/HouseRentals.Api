# HouseRentals

HouseRentals is a web api rest with minimal functionality to manage house rentals.
This project was created to be used together with AWS cloud services.

## DB Installation

This project uses Entity Framework Core to manage the database. To install the database, you need to run the some commands in the Package Manager Console
in the root folder of the project, run the following commands:

```bash
Add-Migration InitialCreate -Context AppDbContext

Update-Database -Context AppDbContext
```

Important: in appsettings.json change the connection string to your database.

## DB Entity Relationship Diagram

![Entity relationship](/Docs/Images/er.png)

There are three entities, showing that this model is simple.
