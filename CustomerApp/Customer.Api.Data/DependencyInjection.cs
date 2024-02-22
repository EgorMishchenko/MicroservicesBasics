using Customer.Api.Data.Contexts;
using Customer.Api.Data.Repository;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Customer.Api.Data
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfigurationManager configManager)
    {
      var sqlConnStr = configManager.GetSection("Customer.Api.Database:ConnectionStrings")["SqlConnectionString"];
      services.AddDbContext<CustomerContext>(options =>
      {
        options.UseSqlServer(sqlConnStr);
      });

      services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
      services.AddTransient<ICustomerRepository, CustomerRepository>();

      return services;
    }
  }
}
