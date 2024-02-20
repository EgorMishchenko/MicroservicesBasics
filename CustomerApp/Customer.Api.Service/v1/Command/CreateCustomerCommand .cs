using Customer.Api.Dtos.v1;
using MediatR;

namespace Customer.Api.Service.v1.Command
{
  public class CreateCustomerCommand : IRequest<CustomerDto>
  {
    public CustomerDto Customer { get; set; }
  }
}
