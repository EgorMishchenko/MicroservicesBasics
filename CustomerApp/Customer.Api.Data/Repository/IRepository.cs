namespace Customer.Api.Data.Repository
{
  public interface IRepository<TEntity> where TEntity : class
  {
    IEnumerable<TEntity> GetAll();
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity> UpdateAsync(TEntity entity);
  }
}
