namespace Customer.Api.Dtos.v1
{
  public record CustomerDto(Guid Id, string FirstName, string LastName, DateTime? Birthday, int? Age);
}
