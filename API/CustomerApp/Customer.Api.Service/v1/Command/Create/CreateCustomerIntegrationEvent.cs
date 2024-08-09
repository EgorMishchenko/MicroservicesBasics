using MediatR;

namespace Customer.Api.Service.v1.Command.Create
{
    public record CreateCustomerIntegrationEvent() : INotification;
}
