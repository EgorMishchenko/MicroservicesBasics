using System.ComponentModel.DataAnnotations;

namespace Order.Api.Contracts
{
  public record CreateOrderRequest(Guid CustomerGuid, string CustomerFullName);
}
