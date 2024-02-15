using FluentValidation;
using MediatR;
using Order.Api.Models.v1;
using Order.Api.Service.v1.Command;
using Order.Api.Validators.v1;
using System.Reflection;

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
      services.AddValidatorsFromAssemblyContaining<OrderModelValidator>();
      services.AddAutoMapper(typeof(Program));
      services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(CreateOrderCommand).Assembly);
      
      return services;
    }

    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
      services.AddTransient<IValidator<OrderModel>, OrderModelValidator>();
      return services;
    }
  }
}
