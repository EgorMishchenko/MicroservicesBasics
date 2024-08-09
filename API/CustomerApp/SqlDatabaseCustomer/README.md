# New SDK-style SQL project with Microsoft.Build.Sql

## Build

To build the project, run the following command:

```bash
dotnet build
```

🎉 Congrats! You have successfully built the project and now have a `dacpac` to deploy anywhere.

## Publish

To publish the project, the SqlPackage CLI or the SQL Database Projects extension for Azure Data Studio/VS Code is required. The following command will publish the project to a local SQL Server instance with port 1488:

Example of local deploy on 1488 port:
```bash
sqlpackage /a:Publish /sf:bin\Debug\SqlDatabaseCustomer.dacpac /tsn:localhost,1488 /tdn:CustomerDb /ttsc:true /p:CommandTimeout=120
```
Template:
```bash
sqlpackage /a:Publish /sf:<path-to-dacpac> /tsn:<server,port> /tdn:<database-name> /ttsc:true /p:CommandTimeout=120
```
NOTE! Database specified in the command will be created automatically.
NOTE! Path to dacpac can be both absolute and relevant

## Install SQL Projects Templates
```bash
dotnet new install Microsoft.Build.Sql.Templates
```

### Install SqlPackage CLI
If you would like to use the command-line utility SqlPackage.exe for deploying the `dacpac`, you can obtain it as a dotnet tool.  The tool is available for Windows, macOS, and Linux.

```bash
dotnet tool install -g microsoft.sqlpackage
```
