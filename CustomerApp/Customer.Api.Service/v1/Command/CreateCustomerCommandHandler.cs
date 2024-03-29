using AutoMapper;
using MediatR;
using Customer.Api.Data.Repository;
using Customer.Api.Dtos.v1;
using Customer.Api.Data.Models;
using Customer.Api.Domain.Entities;

namespace Customer.Api.Service.v1.Command
{
  public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerDto>
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    // Expression body constructor example
    public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
      => (_customerRepository, _mapper) = (customerRepository, mapper);

    public async Task<CustomerDto> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
      var customerEntity = _mapper.Map<CustomerEntity>(request.Customer);

      // todo: business manipulation

      var customerForDb = _mapper.Map<CustomerTable>(customerEntity);
      var customerFromDb = await _customerRepository.AddAsync(customerForDb);
      return _mapper.Map<CustomerDto>(customerFromDb);
    }
  }
}
