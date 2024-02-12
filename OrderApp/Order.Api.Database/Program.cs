using FluentMigrator.Runner;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Order.Api.Database.Configurations;
using Order.Api.Database.Jobs;

namespace Order.Api.Database
{
  public static class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
      return Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
          var globalConnStr = 
            hostContext.Configuration.GetSection("Order.Api.Database:ConnectionStrings")["MasterConnection"];
          services.Configure<DatabaseSettings>(options => hostContext.Configuration.GetSection("Order.Api.Database").Bind(options));

          services.AddFluentMigratorCore()
            .ConfigureRunner(rb => rb
              .AddSqlServer()
              .WithGlobalConnectionString(globalConnStr)
              .ScanIn(typeof(Program).Assembly).For.Migrations())
            .AddLogging(lb => lb.AddFluentMigratorConsole());

          services.AddSingleton<DapperContext>();
          services.AddSingleton<CreateDatabase>();
          services.AddHostedService<Worker>();
        });
    }
  }
}
