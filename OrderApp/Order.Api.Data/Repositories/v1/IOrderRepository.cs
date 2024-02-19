using Order.Api.Domain.Entities;

namespace Order.Api.Data.Repositories.v1
{
  public interface IOrderRepository 
  {
    Task<IEnumerable<Domain.Entities.Order>> GetAllAsync();
    Task<IEnumerable<Domain.Entities.Order>> GetPaidOrdersAsync(CancellationToken cancellationToken);
    Task<Domain.Entities.Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken);
    Task<IEnumerable<Domain.Entities.Order>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken);
    Task AddAsync(Domain.Entities.Order entity);
    Task UpdateAsync(Domain.Entities.Order entity);
    Task UpdateRangeAsync(IEnumerable<Domain.Entities.Order> entities);
  }
}
