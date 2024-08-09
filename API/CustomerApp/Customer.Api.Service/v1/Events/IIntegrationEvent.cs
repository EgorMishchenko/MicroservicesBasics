using MediatR;

namespace Customer.Api.Service.v1.Events;

public interface IIntegrationEvent : INotification
{
    Guid IntegrationEventId { get; init; }
}