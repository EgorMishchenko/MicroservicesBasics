using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Api.Service.Query
{
  public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<Customer>>
  {
    private readonly ICustomerRepository _customerRepository;

    public GetCustomersQueryHandler(ICustomerRepository customerRepository)
    {
      _customerRepository = customerRepository;
    }

    public async Task<List<Customer>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
    {
      return _customerRepository.GetAll().ToList();
    }
  }
}
