using AutoMapper;
using MediatR;
using Customer.Api.Data.Repository;
using Customer.Api.Dtos.v1;
using Customer.Api.Data.Models;
using Customer.Api.Service.v1.Events;
using Customer.Domain.Entities;
using FluentValidation;
using ChanelCreateCustomerIntegrationEvent = Customer.Api.Service.v1.Events.CreateCustomerIntegrationEvent;
using MediatrCreateCustomerIntegrationEvent = Customer.Api.Service.v1.Command.Create.CreateCustomerIntegrationEvent;

namespace Customer.Api.Service.v1.Command.Create
{
    public sealed class CreateCustomerCommandHandler(
        ICustomerRepository customerRepository,
        IValidator<CustomerEntity> customerValidator,
        IMapper mapper,
        IPublisher publisher, // mediatr
        IEventBus eventBus) // channel or smth else
        : IRequestHandler<CreateCustomerCommand, CustomerDto>
    {
        public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customerEntity = mapper.Map<CustomerEntity>(request.Customer);

            var result = await customerValidator.ValidateAsync(customerEntity, cancellationToken);

            if (result.IsValid)
            {
                // demo use of channel (Internal interaction)
                await eventBus.PublishAsync(new ChanelCreateCustomerIntegrationEvent(Guid.NewGuid()), cancellationToken);

                // demo use of Mediatr INotification 
                await publisher.Publish(new MediatrCreateCustomerIntegrationEvent(), cancellationToken);
                
            }
            else
            {
                
            }
            
            CustomerTable? customerForDb = mapper.Map<CustomerTable>(customerEntity);
            CustomerTable? customerFromDb = await customerRepository.AddCustomerAsync(customerForDb);

            return mapper.Map<CustomerDto>(customerFromDb);
        }
    }
}
