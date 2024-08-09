namespace Customer.Api.Service.v1.Events
{
    internal sealed class EventBus : IEventBus
    {
        private readonly InMemoryMessageQueue _queue;

        public EventBus(InMemoryMessageQueue queue)
        {
            _queue = queue;
        }

        public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default) 
            where T : class, IIntegrationEvent
        {
            await _queue.Writer.WriteAsync(integrationEvent, cancellationToken);
        }
    }
}
