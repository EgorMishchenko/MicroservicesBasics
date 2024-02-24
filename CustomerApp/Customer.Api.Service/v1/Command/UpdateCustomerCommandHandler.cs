using MediatR;
using AutoMapper;
using Customer.Api.Data.Models;
using Customer.Api.Dtos.v1;
using Customer.Api.Data.Repository;
using Customer.Api.Messaging.Send.Sender.v1;

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
      var dbCustomer = _mapper.Map<CustomerTable>(request.Customer);
      var customer = await _customerRepository.UpdateAsync(dbCustomer);

      var createdCustomer = _mapper.Map<CustomerDto>(customer);
      _customerUpdateSender.SendCustomer(createdCustomer);

      return createdCustomer;
    }
  }
}
