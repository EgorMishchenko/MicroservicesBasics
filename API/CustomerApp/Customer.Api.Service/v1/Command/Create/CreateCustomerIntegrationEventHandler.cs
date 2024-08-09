using MediatR;

namespace Customer.Api.Service.v1.Command.Create
{
    internal class CreateCustomerIntegrationEventHandler : INotificationHandler<CreateCustomerIntegrationEvent>
    {
        public Task Handle(CreateCustomerIntegrationEvent notification, CancellationToken cancellationToken)
        {
            return Task.Delay(5000, cancellationToken);
        }
    }
}
