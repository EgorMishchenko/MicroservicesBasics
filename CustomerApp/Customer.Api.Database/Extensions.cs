using Customer.Api.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Customer.Api.Database
{
  internal static class Extensions
  {
    public static IHost MigrateDatabase(this IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var context = scope.ServiceProvider.GetRequiredService<CustomerContext>();
        context.Database.Migrate();
      }

      return host;
    }

    public static IHost SeedData(this IHost host)
    {
      using (var scope = host.Services.CreateScope())
      {
        var env = scope.ServiceProvider.GetRequiredService<IHostEnvironment>();
        if (env.IsDevelopment())
        {
          var context = scope.ServiceProvider.GetRequiredService<CustomerContext>();
          TestData.Seed(context);
        }
      }

      return host;
    }
  }
}
