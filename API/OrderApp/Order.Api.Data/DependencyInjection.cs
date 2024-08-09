using Microsoft.Extensions.DependencyInjection;
using Order.Api.Data.Repositories.v1;

namespace Order.Api.Data
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
      services.AddScoped<IOrderRepository, OrderRepository>();

      return services;
    }
  }
}
