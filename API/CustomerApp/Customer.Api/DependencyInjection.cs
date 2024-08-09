using System.Reflection;
using System.Text;
using Customer.Api.Contracts;
using Customer.Api.Data.Configuration;
using Customer.Api.Utilities;
using Customer.Api.Validators.v1;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Customer.Api
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApiDependencies(this IServiceCollection services, IConfigurationManager configManager)
    {
      services.AddAutoMapper(Assembly.GetExecutingAssembly());
      services.AddUtilities();
      services.AddRequestValidators();
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

    private static IServiceCollection AddRequestValidators(this IServiceCollection services)
    {
      services.AddScoped<IValidator<CreateCustomerRequest>, CreateCustomerRequestValidator>();

      return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfigurationManager configManager)
    {
      services.AddAuthentication(x =>
      {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(x =>
      {
        x.TokenValidationParameters = new TokenValidationParameters()
        {
          ValidIssuer = configManager["JwtSettings:Issuer"],
          ValidAudience = configManager["JwtSettings:Audience"],
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configManager["JwtSettings:Key"]!)),
          ValidateIssuer = true,
          ValidateAudience = true,
          ValidateLifetime = true,
          ValidateIssuerSigningKey = true,
        };
      });

      services.AddAuthorization();

      return services;
    }
  }
}
