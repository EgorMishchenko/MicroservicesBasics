echo "start sh script"
echo "Run init-script with long timeout - and make it run in the background"
# Run init-script with long timeout - and make it run in the background
##/opt/mssql-tools/bin/sqlcmd -S localhost -l 1433 -U sa -P "P+Lv27vGUH7e"

echo "Start SQL server"
# Start SQL server
/opt/mssql/bin/sqlservr

sleep 60
echo "Deploy CustomerDb"
# Deploy CustomerDb
#/opt/sqlpackage/sqlpackage /a:Publish /sf:SqlDatabaseCustomer.dacpac /tsn:host.docker.internal /tdn:CustomerDb /ttsc:true /tu:sa /tp:"P+Lv27vGUH7e" /p:CommandTimeout=120
#/opt/sqlpackage/sqlpackage /a:Publish /sf:SqlDatabaseCustomer.dacpac /tsn:172.17.0.1,1433 /tdn:CustomerDb /ttsc:true /tu:sa /tp:"P+Lv27vGUH7e" /p:CommandTimeout=120

echo "end sh script"