using Dapper;
using Order.Api.Data.Database;
using Order.Api.Domain.Entities;
using System.Data;
namespace Order.Api.Data.Repositories.v1
{
  public sealed class OrderRepository : IOrderRepository
  {
    private readonly DapperContext _dbContext;
    public OrderRepository(DapperContext dbContext)
    {
      _dbContext = dbContext;
    }
    public async Task<IEnumerable<OrderEntity>> GetAllAsync()
    {
      try
      {
        var query = "SELECT * FROM Order";

        using (var connection = _dbContext.CreateConnection())
        {
          return await connection.QueryAsync<OrderEntity>(query);
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Couldn't retrieve entities {ex.Message}");
      }
    }

    public async Task<IEnumerable<OrderEntity>> GetPaidOrdersAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<OrderEntity> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<OrderEntity>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task AddAsync(OrderEntity entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
      }

      try
      {
        var query = @"INSERT INTO Order (Name, Address, Country) 
                      VALUES (@OrderState, @CustomerGuid, @CustomerFullName)";

        var parameters = new DynamicParameters();
        parameters.Add("OrderState", entity.OrderState, DbType.Int32);
        parameters.Add("CustomerGuid", entity.CustomerGuid, DbType.Guid);
        parameters.Add("CustomerFullName", entity.CustomerFullName, DbType.String);

        using (var connection = _dbContext.CreateConnection())
        {
          await connection.ExecuteAsync(query, parameters);
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"{nameof(entity)} could not be saved {ex.Message}");
      }
    }

    public async Task UpdateAsync(OrderEntity entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
      }

      try
      {
        var query = @"UPDATE Order (OrderState, CustomerGuid, CustomerFullName) 
                      VALUES (@OrderState, @CustomerGuid, @CustomerFullName)";

        var parameters = new DynamicParameters();
        parameters.Add("OrderState", entity.OrderState, DbType.Int32);
        parameters.Add("CustomerGuid", entity.CustomerGuid, DbType.Guid);
        parameters.Add("CustomerFullName", entity.CustomerFullName, DbType.String);

        using (var connection = _dbContext.CreateConnection())
        {
          await connection.ExecuteAsync(query, parameters);
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
      }
    }

    public async Task UpdateRangeAsync(IEnumerable<OrderEntity> entities)
    {
      throw new NotImplementedException();
    }
  }
}
