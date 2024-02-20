using Customer.Api.Dtos.v1;
using MediatR;

namespace Customer.Api.Service.v1.Query
{
  public class GetCustomersQuery : IRequest<IEnumerable<CustomerDto>>
  {
  }
}
