using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using Order.Api.Database.Configurations;

namespace Order.Api.Data.Database
{
  public class DapperContext 
  {
    private readonly IOptions<DatabaseOptions> _settings;
    public DapperContext(IOptions<DatabaseOptions> settings)
    {
      _settings = settings;
    }

    public IDbConnection CreateConnection()
      => new SqlConnection(_settings.Value.ConnectionStrings.SqlConnection);
    public IDbConnection CreateMasterConnection()
      => new SqlConnection(_settings.Value.ConnectionStrings.MasterConnection);
  }
}
