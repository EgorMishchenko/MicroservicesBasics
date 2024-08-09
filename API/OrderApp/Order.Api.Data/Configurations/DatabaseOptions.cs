using Order.Api.Data.Configurations;

namespace Order.Api.Database.Configurations
{
  public class DatabaseOptions
  {
    public string DatabaseName { get; set; }
    public ConnectionStrings ConnectionStrings { get; set; }
  }
}
