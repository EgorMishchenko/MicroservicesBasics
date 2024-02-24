namespace Customer.Api.Data.Models
{
  public record CustomerTable(Guid Id, string FirstName, string LastName, DateOnly? Birthday);

}
