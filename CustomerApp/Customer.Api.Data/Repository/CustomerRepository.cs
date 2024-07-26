using Customer.Api.Data.Contexts;
using Customer.Api.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer.Api.Data.Repository
{
  public class CustomerRepository(CustomerContext customerContext) : ICustomerRepository
  {
    public IEnumerable<CustomerTable> GetAllCustomers()
    {
      try
      {
        return customerContext.Set<CustomerTable>();
      }
      catch (Exception ex)
      {
        throw new Exception($"Couldn't retrieve entities: {ex.Message}");
      }
    }

    public async Task<CustomerTable> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var customer = await customerContext.Customer.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (customer == null)
        {
            return default;
        }

        return customer;
    }

    public async Task<IEnumerable<CustomerTable>> GetCustomersByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await customerContext.Customer.Where(x => x.Email == email).ToListAsync(cancellationToken);
    }

    public async Task<CustomerTable> AddCustomerAsync(CustomerTable customerTable)
    {
      if (customerTable == null)
      {
        throw new ArgumentNullException($"{nameof(AddCustomerAsync)} entity must not be null");
      }

      try
      {
        await customerContext.AddAsync(customerTable);
        await customerContext.SaveChangesAsync();

        return customerTable;
      }
      catch (Exception ex)
      {
        throw new Exception($"{nameof(customerTable)} could not be saved: {ex.Message}");
      }
    }

    public async Task<CustomerTable> UpdateCustomerAsync(CustomerTable entity)
    {
      if (entity == null)
      {
        throw new ArgumentNullException($"{nameof(UpdateCustomerAsync)} entity must not be null");
      }

      try
      {
        customerContext.Update(entity);
        await customerContext.SaveChangesAsync();

        return entity;
      }
      catch (Exception ex)
      {
        throw new Exception($"{nameof(entity)} could not be updated {ex.Message}");
      }
    }
  }
}
