using MediatR;
using Order.Api.Dtos.v1;

namespace Order.Api.Service.v1.Commands
{
    public record CreateOrderCommand(OrderDto Order) : IRequest;
}
