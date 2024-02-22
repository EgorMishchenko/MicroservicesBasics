using Customer.Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer.Api.Database
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args)
        .Build()
        .MigrateDatabase()
        .SeedData()
        .Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
          var globalConnStr =
            hostContext.Configuration.GetSection("Customer.Api.Database:ConnectionStrings")["SqlConnectionString"];

          services.AddDbContext<CustomerContext>(opts => opts.UseSqlServer(globalConnStr));
        });
    }
  }
}
