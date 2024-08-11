using Microsoft.Extensions.DependencyInjection;
using Identity.Data.Repositories;

namespace Identity.Data
{
    public static class DependencyInjection
  {
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
      services.AddTransient<ITokenRepository, TokenRepository>();

      return services;
    }
  }
}
