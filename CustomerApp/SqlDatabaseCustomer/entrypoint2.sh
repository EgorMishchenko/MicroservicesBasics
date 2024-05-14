echo "start sh script"

/tmp/sqlpackage /a:Publish /sf:/src/bin/Debug/SqlDatabaseCustomer.dacpac /tsn:localhost,1644 /tdn:CustomerDb /ttsc:true /tu:sa /tp:"P+Lv27vGUH7e" /p:CommandTimeout=120

echo "end sh script"