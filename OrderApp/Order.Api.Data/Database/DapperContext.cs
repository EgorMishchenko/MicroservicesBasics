using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Order.Api.Data.Database
{
  public class DapperContext 
  {
    private readonly IConfiguration _configuration;
    public DapperContext(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    public IDbConnection CreateConnection()
      => new SqlConnection(_configuration.GetConnectionString("SqlConnection"));
    public IDbConnection CreateMasterConnection()
      => new SqlConnection(_configuration.GetConnectionString("MasterConnection"));
  }
}
