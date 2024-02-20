namespace Customer.Api.Contracts
{
  public record GetCustomersResponse(IEnumerable<Customer> Customers);
}
