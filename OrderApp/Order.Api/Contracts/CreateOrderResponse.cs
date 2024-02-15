namespace Order.Api.Contracts
{
  public class CreateOrderResponse
  {
    public Guid Id { get; set; }

    public int OrderState { get; set; }

    public Guid CustomerGuid { get; set; }

    public string CustomerFullName { get; set; }
  }
}
