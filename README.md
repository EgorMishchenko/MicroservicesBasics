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
For API:
docker build -t customerapi:1.0 .
docker build -t orderapi:1.0 .

To deploy DB:
docker build -t customerapidatabase:latest -f Dockerfile.Database .
docker build -t orderapidatabase:latest -f Dockerfile.Database .

