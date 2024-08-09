using AutoMapper;
using MediatR;
using Customer.Api.Data.Repository;
using Customer.Api.Dtos.v1;

namespace Customer.Api.Service.v1.Query
{
  public class GetCustomersQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
      : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
  {
      public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
      var customersFromDb = customerRepository.GetAllCustomers().ToList();
      var mappedCustomers = mapper.Map<List<CustomerDto>>(customersFromDb);

      return mappedCustomers;
    }
  }
}
