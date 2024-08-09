namespace Customer.Api.Service.v1.Events
{
    public record CreateCustomerIntegrationEvent(Guid IntegrationEventId) : IntegrationEvent(IntegrationEventId);
}
