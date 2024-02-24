using System.ComponentModel.DataAnnotations;

namespace Customer.Api.Contracts
{
  public record CreateCustomerRequest([Required] string FirstName, [Required] string LastName, DateTime? Birthday);
}
