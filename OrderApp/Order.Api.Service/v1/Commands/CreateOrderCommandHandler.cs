using MediatR;
using Order.Api.Data.Repositories.v1;
using Order.Api.Domain.Entities;

namespace Order.Api.Service.v1.Commands
{
  public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, OrderEntity>
  {
    private readonly IOrderRepository _orderRepository;

    public CreateOrderCommandHandler(IOrderRepository orderRepository)
    {
      _orderRepository = orderRepository;
    }

    public async Task<OrderEntity> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
      return await _orderRepository.AddAsync(request.Order);
    }
  }
}
