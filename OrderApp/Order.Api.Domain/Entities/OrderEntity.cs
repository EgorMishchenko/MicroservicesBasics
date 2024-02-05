namespace Order.Api.Domain.Entities
{
  public sealed class OrderEntity
  {
    public Guid Id { get; set; }

    public int OrderState { get; set; }

    public Guid CustomerGuid { get; set; }

    public string CustomerFullName { get; set; }
  }
}
