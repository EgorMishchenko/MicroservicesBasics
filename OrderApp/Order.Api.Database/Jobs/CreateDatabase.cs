using Dapper;
using Microsoft.Extensions.Options;
using Order.Api.Data.Database;
using Order.Api.Database.Configurations;

namespace Order.Api.Database.Jobs
{
  internal sealed class CreateDatabase
  {
    private readonly DapperContext _context;

    public CreateDatabase(DapperContext context)
    {
        _context = context;
    }

    public void Run(IOptions<DatabaseSettings> settings)
    {
      var dbName = settings.Value.DatabaseName;
      var query = "SELECT * FROM sys.databases WHERE name = @name";
      var parameters = new DynamicParameters();
      parameters.Add("name", dbName);

      using (var connection = _context.CreateMasterConnection())
      {
        var records = connection.Query(query, parameters);
        if (!records.Any())
        {
            connection.Execute($"CREATE DATABASE {dbName}");
        }
      }
    }
  }
}
