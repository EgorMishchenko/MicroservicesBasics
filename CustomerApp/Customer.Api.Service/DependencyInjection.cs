using Customer.Api.Dtos.v1;
using Customer.Api.Service.v1.Query;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace Customer.Api.Service
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
      services.AddTransient<IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>, GetCustomersQueryHandler>();

      return services;
    }
  }
}
