namespace Customer.Api.Service.v1.Events
{
    public interface IEventBus
    {
        Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
            where T: class, IIntegrationEvent;
    }
}
