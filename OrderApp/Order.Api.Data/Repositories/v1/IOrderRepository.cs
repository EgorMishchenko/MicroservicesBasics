using Order.Api.Domain.Entities;

namespace Order.Api.Data.Repositories.v1
{
  public interface IOrderRepository 
  {
    Task<IEnumerable<OrderEntity>> GetAllAsync();
    Task<IEnumerable<OrderEntity>> GetPaidOrdersAsync(CancellationToken cancellationToken);
    Task<OrderEntity> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken);
    Task<IEnumerable<OrderEntity>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken);
    Task AddAsync(OrderEntity entity);
    Task UpdateAsync(OrderEntity entity);
    Task UpdateRangeAsync(IEnumerable<OrderEntity> entities);
  }
}
