using System.Data;
using AutoMapper;
using Dapper;
using Order.Api.Data.Database;
using Order.Api.Data.Models;

namespace Order.Api.Data.Repositories.v1
{
  public sealed class OrderRepository : IOrderRepository
  {
    private readonly DapperContext _dbContext;
    private readonly IMapper _mapper;

    public OrderRepository(DapperContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }
    public async Task<IEnumerable<Domain.Entities.Order>> GetAllAsync()
    {
      try
      {
        var query = "SELECT * FROM Order";

        using (var connection = _dbContext.CreateConnection())
        {
          var ordersFromDb = await connection.QueryAsync<OrderTable>(query);
          return _mapper.Map<IEnumerable<Domain.Entities.Order>>(ordersFromDb);
        }
      }
      catch (Exception ex)
      {
        throw new Exception($"Couldn't retrieve entities {ex.Message}");
      }
    }

    public async Task<IEnumerable<Domain.Entities.Order>> GetPaidOrdersAsync(CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<Domain.Entities.Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task<IEnumerable<Domain.Entities.Order>> GetOrderByCustomerGuidAsync(Guid customerId, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }

    public async Task AddAsync(Domain.Entities.Order entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
      }

      try
      {
        var dbOrder = _mapper.Map<OrderTable>(entity);
        var query = @"INSERT INTO Order (Name, Address, Country) 
                      VALUES (@OrderState, @CustomerGuid, @CustomerFullName)";

        var parameters = new DynamicParameters();
        parameters.Add("OrderState", dbOrder.OrderState, DbType.Int32);
        parameters.Add("CustomerGuid", dbOrder.CustomerGuid, DbType.Guid);
        parameters.Add("CustomerFullName", dbOrder.CustomerFullName, DbType.String);

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

    public async Task UpdateAsync(Domain.Entities.Order entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
      }

      try
      {
        var dbOrder = _mapper.Map<OrderTable>(entity);

        var query = @"UPDATE Order (OrderState, CustomerGuid, CustomerFullName) 
                      VALUES (@OrderState, @CustomerGuid, @CustomerFullName)";

        var parameters = new DynamicParameters();
        parameters.Add("OrderState", dbOrder.OrderState, DbType.Int32);
        parameters.Add("CustomerGuid", dbOrder.CustomerGuid, DbType.Guid);
        parameters.Add("CustomerFullName", dbOrder.CustomerFullName, DbType.String);

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

    public async Task UpdateRangeAsync(IEnumerable<Domain.Entities.Order> entities)
    {
      throw new NotImplementedException();
    }
  }
}
