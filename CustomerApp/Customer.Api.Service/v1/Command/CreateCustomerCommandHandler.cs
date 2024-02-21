using AutoMapper;
using MediatR;
using Customer.Api.Data.Repository;
using Customer.Api.Dtos.v1;
using Customer.Api.Data.Models;

namespace Customer.Api.Service.v1.Command
{
  public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
      _customerRepository = customerRepository;
      _mapper = mapper;
    }

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
      var customerForDb = _mapper.Map<CustomerTable>(request.Customer);
      var customerFromDb = await _customerRepository.AddAsync(customerForDb);
      return _mapper.Map<CustomerDto>(customerFromDb);
    }
  }
}
