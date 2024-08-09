using System.ComponentModel.DataAnnotations;

namespace Order.Api.Dtos.v1
{
  public record OrderDto([Required] Guid CustomerGuid, [Required] string CustomerFullName);
}
