namespace Customer.Api.Contracts
{
  public record Customer(Guid Id, string FirstName, string LastName, DateTime? Birthday, int? Age);
}
