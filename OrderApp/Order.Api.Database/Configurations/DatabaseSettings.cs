namespace Order.Api.Database.Configurations
{
  internal class DatabaseSettings
  {
    public string DatabaseName { get; set; }
    public ICollection<string> ConnectionStrings { get; set; }
  }
}
