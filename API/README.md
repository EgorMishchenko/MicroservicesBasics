# MicroservicesBasics
Two microservices with basic functionality.

## Technologies:

- .NET 6
- Swagger
- Asynchronous messaging using RabbitMQ
- Docker

## Getting started:
#### Create imgage for Customer.Api service:

Docker commands:
For API move to folder and execute:
docker build -t customerapi:1.0 .
docker build -t orderapi:1.0 .
docker build -t securityapi:1.0 -f Dockerfile.SecurityApp .

To deploy DB:
docker build -t customerapidatabase:latest -f Dockerfile.Database .
docker build -t orderapidatabase:latest -f Dockerfile.Database .

#### Creating migrations
1) dotnet ef migrations add <initial_migration_name> (Create_Database or Initial)
- creating c# code that represent database structure and data

this stage should be run by developer to generate code

2) to create database and with data we can just build the project
(this method should be executed - context.Database.Migrate();)

in command line:
dotnet ef database update


