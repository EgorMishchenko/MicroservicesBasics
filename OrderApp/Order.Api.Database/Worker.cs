using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Order.Api.Database.Configurations;
using Order.Api.Database.Jobs;

namespace Order.Api.Database
{
  internal class Worker : IHostedService
  {
    private readonly IHostApplicationLifetime _host;
    private readonly CreateDatabase _createDatabase;
    private readonly IOptions<DatabaseSettings> _settings;

    private ILogger<Worker> _logger;
    
    public Worker(IHostApplicationLifetime host,
      IOptions<DatabaseSettings> settings,
      CreateDatabase createDatabase,
      ILogger<Worker> logger)
    {
      _host = host;
      _settings = settings;
      _createDatabase = createDatabase; 
      _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("start migration worker async");

      _createDatabase.Run(_settings);

      _host.StopApplication();
      return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
      _logger.LogInformation("Stop migration worker async");
      return Task.CompletedTask;
    }
  }
}
