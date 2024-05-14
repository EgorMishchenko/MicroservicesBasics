using System.Reflection;
using Customer.Api.Contracts;
using Customer.Api.Data.Configuration;
using Customer.Api.Utilities;
using Customer.Api.Validators.v1;
using FluentValidation;

namespace Customer.Api
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfigurationManager configManager)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddUtilities();
      services.AddValidator();
      services.AddControllers();
      services.AddEndpointsApiExplorer();
      services.AddSwaggerGen();
      services.AddProblemDetails();

      services.Configure<DatabaseConfig>(options =>
        configManager.GetSection("Customer.Api.Database:ConnectionStrings").Bind(options));

      return services;
    }

    private static IServiceCollection AddUtilities(this IServiceCollection services)
    {
        services.AddSingleton<IDateTimeProvider, DefaultDateTimeProvider>();
        return services;
    }

    private static IServiceCollection AddValidator(this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerRequestValidator>();
        return services;
    }
  }
}
