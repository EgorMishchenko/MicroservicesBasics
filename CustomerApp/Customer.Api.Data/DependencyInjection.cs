using Customer.Api.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using Customer.Api.Data.Repository;

namespace Customer.Api.Data
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
      services.AddDbContext<CustomerContext>();
      services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
      services.AddTransient<ICustomerRepository, CustomerRepository>();

      return services;
    }
  }
}
