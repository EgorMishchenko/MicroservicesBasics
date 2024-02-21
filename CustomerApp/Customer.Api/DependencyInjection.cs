using System.Reflection;
using Customer.Api.Service.v1.Query;

namespace Customer.Api
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApiDependencies(this IServiceCollection services)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      services.AddProblemDetails();

      return services;
    }

    // todo: move to service
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
      services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetCustomersQueryHandler).GetTypeInfo().Assembly));

      return services;
    }
  }
}
