using Customer.Api.Dtos.v1;
using MediatR;

namespace Customer.Api.Service.v1.Command.Update
{
    public record UpdateCustomerCommand(CustomerDto Customer) : IRequest<CustomerDto>;
}
