using Order.Api.Domain.Entities;

namespace Order.Api.Data.Repositories.v1
{
  public sealed class OrderRepository : Repository<OrderEntity>, IOrderRepository
  {
    public IEnumerable<OrderEntity> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<OrderEntity> AddAsync(OrderEntity entity)
    {
      throw new NotImplementedException();
    }

    public async Task<OrderEntity> UpdateAsync(OrderEntity entity)
    {
      throw new NotImplementedException();
    }

    public async Task UpdateRangeAsync(List<OrderEntity> entities)
    {
      throw new NotImplementedException();
    }
  }
}
