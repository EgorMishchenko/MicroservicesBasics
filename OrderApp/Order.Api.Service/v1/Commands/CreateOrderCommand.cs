using MediatR;
using Order.Api.Domain.Entities;

namespace Order.Api.Service.v1.Commands
{
    public record CreateOrderCommand(OrderModel Order) : IRequest<OrderModel>;
}
