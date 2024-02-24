using Customer.Api.Messaging.Send.Sender.v1;
using Microsoft.Extensions.DependencyInjection;

namespace Customer.Api.Messaging.Send
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddMessagingDependencies(this IServiceCollection services)
    {
      services.AddTransient<ICustomerUpdateSender, CustomerUpdateSender>();
      return services;
    }
  }
}
