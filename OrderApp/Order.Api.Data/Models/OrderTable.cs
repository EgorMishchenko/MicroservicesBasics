namespace Order.Api.Data.Models
{
  public record OrderTable(Guid Id, int OrderState, Guid CustomerGuid, string CustomerFullName);
}
