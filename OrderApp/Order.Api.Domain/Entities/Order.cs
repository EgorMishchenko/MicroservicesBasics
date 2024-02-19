namespace Order.Api.Domain.Entities
{
  public record Order(Guid Id, int OrderState, Guid CustomerGuid, string CustomerFullName);
}
