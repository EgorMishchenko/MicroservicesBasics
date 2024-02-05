using MediatR;
using Order.Api.Domain.Entities;

namespace Order.Api.Service.Command
{
  public record CreateOrderCommand(OrderEntity Order) : IRequest<OrderEntity>;
}
