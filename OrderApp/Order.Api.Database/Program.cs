using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order.Api.Data.Database;
using Order.Api.Database.Configurations;
using Order.Api.Database.Jobs;
using System.Reflection;

namespace Order.Api.Database
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args)
        .Build()
        .MigrateDatabase()
        .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
          var globalConnStr = 
            hostContext.Configuration.GetSection("Order.Api.Database:ConnectionStrings")["MasterConnection"];

          services.Configure<DatabaseOptions>(options => hostContext.Configuration.GetSection("Order.Api.Database")
            .Bind(options));

          services
            .AddLogging(lb => lb.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
              .AddSqlServer()
              .WithGlobalConnectionString(globalConnStr)
              .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations());
            
          services.AddSingleton<DapperContext>();
          services.AddSingleton<CreateDatabase>();
        });
    }
  }
}
