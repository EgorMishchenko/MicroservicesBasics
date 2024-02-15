using FluentValidation;
using MediatR;
using Order.Api.Validators.v1;
using System.Reflection;
using Order.Api.Dtos.v1;
using Order.Api.Service.v1.Commands;
using Order.Api.Contracts;

namespace Order.Api
{
    public static class DependencyInjection
  {
    public static IServiceCollection AddApiDependencies(this IServiceCollection services)
    {
      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      services.AddProblemDetails();

      services.AddInfrastructure();
      services.AddValidation();
      return services;
    }

    private static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      services.AddValidatorsFromAssemblyContaining<CreateOrderRequestValidator>();
      services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateOrderCommand).Assembly);
      
      return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
      services.AddTransient<IValidator<CreateOrderRequest>, CreateOrderRequestValidator>();
      return services;
    }
  }
}
