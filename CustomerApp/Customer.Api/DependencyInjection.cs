using System.Reflection;
using Customer.Api.Data.Configuration;
using Customer.Api.Service.v1.Query;

namespace Customer.Api
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfigurationManager configManager)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      services.AddProblemDetails();

      services.Configure<DatabaseConfig>(options =>
        configManager.GetSection("Customer.Api.Database:ConnectionStrings").Bind(options));

      return services;
    }
  }
}
