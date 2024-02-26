#build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src
COPY ["Customer.Api/Customer.Api.csproj", "Customer.Api/"]
COPY ["Customer.Api.Data/Customer.Api.Data.csproj", "Customer.Api.Data/"]
COPY ["Customer.Api.Database/Customer.Api.Database.csproj", "Customer.Api.Database/"]
COPY ["Customer.Api.Domain/Customer.Api.Domain.csproj", "Customer.Api.Domain/"]
COPY ["Customer.Api.Dtos/Customer.Api.Dtos.csproj", "Customer.Api.Dtos/"]
COPY ["Customer.Api.Messaging.Send/Customer.Api.Messaging.Send.csproj", "Customer.Api.Messaging.Send/"]
COPY ["Customer.Api.Service/Customer.Api.Service.csproj", "Customer.Api.Service/"]

RUN dotnet restore "Customer.Api/Customer.Api.csproj"
RUN dotnet publish "Customer.Api/Customer.Api.csproj" --no-restore -c Release -o /app/publish

#serve stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY --from=build-env /app/publish .

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Customer.Api.dll"]