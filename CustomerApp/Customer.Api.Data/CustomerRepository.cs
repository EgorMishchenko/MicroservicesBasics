namespace Customer.Api.Data
{
  public class CustomerRepository : ICustomerRepository
  {
    public async Task<Customer> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
    {
      throw new NotImplementedException();
    }
  }
}
