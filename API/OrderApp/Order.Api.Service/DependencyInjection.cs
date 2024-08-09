using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Api.Service.v1.Commands;

namespace Order.Api.Service
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
      services.AddTransient<IRequestHandler<CreateOrderCommand>, CreateOrderCommandHandler>();

      return services;
    }
  }
}
