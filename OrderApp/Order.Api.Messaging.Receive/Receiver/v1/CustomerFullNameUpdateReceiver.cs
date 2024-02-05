using Microsoft.Extensions.Hosting;

namespace Order.Api.Messaging.Receive.Receiver.v1
{
  public sealed class CustomerFullNameUpdateReceiver : BackgroundService
  {
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      throw new NotImplementedException();
    }
  }
}
