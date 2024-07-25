using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Customer.Api.Service.v1.Events
{
    internal sealed class IntegrationEventProcessorJob : BackgroundService
    {
        private readonly InMemoryMessageQueue _queue;
        private readonly IPublisher _publisher;
        private readonly ILogger<IntegrationEventProcessorJob> _logger;

        public IntegrationEventProcessorJob(
            InMemoryMessageQueue queue, 
            IPublisher publisher, 
            ILogger<IntegrationEventProcessorJob> logger)
        {
            _queue = queue;
            _publisher = publisher;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await foreach (var integrationEvent in _queue.Reader.ReadAllAsync(stoppingToken))
            {
                _logger.LogInformation("Publishing {IntegrationEventId}", integrationEvent.IntegrationEventId);

                try
                {
                    await _publisher.Publish(integrationEvent, stoppingToken);
                }
                catch (Exception)
                {
                    _logger.LogError("Failed to publish {IntegrationEventId}", integrationEvent.IntegrationEventId);
                }
               

                _logger.LogInformation("Processed {IntegrationEventId}", integrationEvent.IntegrationEventId);
            }
        }
    }
}
