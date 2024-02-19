using FluentMigrator.Runner;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Order.Api.Database.Configurations;
using Order.Api.Database.Jobs;
using Microsoft.Extensions.DependencyInjection;

namespace Order.Api.Database
{
  internal static class Extensions
  {
    public static IHost MigrateDatabase(this IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var createDatabase = scope.ServiceProvider.GetRequiredService<CreateDatabase>();
        var settings = scope.ServiceProvider.GetRequiredService<IOptions<DatabaseOptions>>();
        var migrationService = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        try
        {
          createDatabase.Run(settings);

          migrationService.ListMigrations();
          migrationService.MigrateUp();
        }
        catch (Exception ex) 
        {
          logger.LogError(ex.Message);
        }
      }
      return host;
    }
  }
}
