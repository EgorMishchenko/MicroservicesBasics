FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /src
COPY ["PostDeploy", "PostDeploy"]
COPY ["PreDeploy", "PreDeploy"]
COPY ["SqlDatabaseCustomer.sqlproj", ""]
COPY ["entrypoint2.sh", "/tmp"]

RUN dotnet build

RUN dotnet tool install --tool-path /tmp microsoft.sqlpackage

CMD ["sh", "/tmp/entrypoint2.sh"]

