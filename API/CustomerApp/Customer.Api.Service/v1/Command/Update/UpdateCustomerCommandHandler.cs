using MediatR;
using AutoMapper;
using Customer.Api.Data.Models;
using Customer.Api.Dtos.v1;
using Customer.Api.Data.Repository;
using Customer.Api.Messaging.Send.Sender.v1;
using Customer.Api.Service.v1.Command.Update;
using Customer.Domain.Entities;

namespace Customer.Api.Service.v1.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerDto>
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly ICustomerUpdateSender _customerUpdateSender;
    private readonly IMapper _mapper;

    public UpdateCustomerCommandHandler(ICustomerUpdateSender customerUpdateSender, ICustomerRepository customerRepository, IMapper mapper)
    {
      _customerUpdateSender = customerUpdateSender;
      _customerRepository = customerRepository;
      _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
      var customerEntity = _mapper.Map<CustomerEntity>(request.Customer);

      // todo: business manipulation

      var updatedCustomerEntity = await UpdateDatabaseAsync(customerEntity);

      await UpdateInOtherServicesAsync(updatedCustomerEntity);

      return _mapper.Map<CustomerDto>(updatedCustomerEntity);
    }

    private async Task<CustomerEntity> UpdateDatabaseAsync(CustomerEntity customerEntity)
    {
      var dbCustomer = _mapper.Map<CustomerTable>(customerEntity);
      var customer = await _customerRepository.UpdateCustomerAsync(dbCustomer);
      return _mapper.Map<CustomerEntity>(customer);
    }

    private async Task UpdateInOtherServicesAsync(CustomerEntity customerEntity)
    {
      var createdCustomer = _mapper.Map<CustomerDto>(customerEntity);
      _customerUpdateSender.SendCustomer(createdCustomer);
    }
  }
}
