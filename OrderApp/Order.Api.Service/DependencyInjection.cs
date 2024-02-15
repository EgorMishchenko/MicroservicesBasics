using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Order.Api.Domain.Entities;
using Order.Api.Service.v1.Command;

namespace Order.Api.Service
{
    public static class DependencyInjection
  {
    public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
    {
      services.AddTransient<IRequestHandler<CreateOrderCommand, OrderEntity>, CreateOrderCommandHandler>();

      return services;
    }
  }
}
