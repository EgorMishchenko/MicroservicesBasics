using Customer.Api.Messaging.Send.Sender.v1;
using Customer.Api.Messaging.Send.Options.v1;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace Customer.Api.Messaging.Send
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddMessagingDependencies(this IServiceCollection services, IConfigurationManager configManager)
    {
      services.Configure<RabbitMqConfiguration>(options =>
        configManager.GetSection("Customer.Api.Database:Messaging").Bind(options));

      services.AddTransient<ICustomerUpdateSender, CustomerUpdateSender>();
      return services;
    }
  }
}
