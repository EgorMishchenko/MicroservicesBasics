using System.ComponentModel.DataAnnotations;

namespace Order.Api.Contracts
{
  public class CreateOrderRequest
  {
    [Required]
    public Guid CustomerGuid { get; set; }

    [Required]
    public string CustomerFullName { get; set; }
  }
}
