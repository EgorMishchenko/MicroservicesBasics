using AutoMapper;
using MediatR;
using Order.Api.Data.Repositories.v1;

namespace Order.Api.Service.v1.Commands
{
  public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
  {
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
      _orderRepository = orderRepository;
      _mapper = mapper;
    }

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
      var order = _mapper.Map<Domain.Entities.Order>(request.Order);
      await _orderRepository.AddAsync(order);
    }
  }
}
