using Customer.Api.Dtos.v1;
using Customer.Api.Service.v1.Query;
using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Customer.Api.Service
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCustomersQueryHandler).GetTypeInfo().Assembly));

      services.AddTransient<IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>, GetCustomersQueryHandler>();

      return services;
    }
  }
}
