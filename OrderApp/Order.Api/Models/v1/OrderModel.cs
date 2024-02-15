using System.ComponentModel.DataAnnotations;

namespace Order.Api.Models.v1
{
  public class OrderModel
  {
    [Required] 
    public Guid CustomerGuid { get; set; }

    [Required] 
    public string CustomerFullName { get; set; }
  }
}
