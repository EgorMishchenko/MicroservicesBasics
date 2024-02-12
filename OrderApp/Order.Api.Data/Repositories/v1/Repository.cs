using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Api.Data.Repositories.v1
{
  public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
  {
    public IEnumerable<TEntity> GetAll()
    {
      throw new NotImplementedException();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
      throw new NotImplementedException();
    }

    public async Task<TEntity> UpdateAsync(TEntity entity)
    {
      throw new NotImplementedException();
    }

    public async Task UpdateRangeAsync(List<TEntity> entities)
    {
      throw new NotImplementedException();
    }
  }
}
