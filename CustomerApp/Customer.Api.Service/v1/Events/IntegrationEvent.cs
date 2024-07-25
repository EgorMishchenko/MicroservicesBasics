namespace Customer.Api.Service.v1.Events;

public abstract record IntegrationEvent(Guid IntegrationEventId) : IIntegrationEvent;
