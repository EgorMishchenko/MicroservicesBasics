namespace Customer.Api.Data.Models
{
  public record CustomerTable(Guid Id, string FirstName, string LastName, DateTime? Birthday, int? Age);

}
