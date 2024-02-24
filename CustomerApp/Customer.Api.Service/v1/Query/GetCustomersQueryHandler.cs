using AutoMapper;
using MediatR;
using Customer.Api.Data.Repository;
using Customer.Api.Dtos.v1;

namespace Customer.Api.Service.v1.Query
{
  public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
  {
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
    {
      _customerRepository = customerRepository;
      _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
      var customersFromDb = _customerRepository.GetAll().ToList();
      var mappedCustomers = _mapper.Map<List<CustomerDto>>(customersFromDb);
      return await Task.FromResult(mappedCustomers);
    }
  }
}
