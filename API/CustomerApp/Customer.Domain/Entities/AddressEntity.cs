namespace Customer.Domain.Entities
{
  public class AddressEntity
  {
    // street and house/building etc e.g. "2566 Dow ST"
    public int AddressId { get; set; }

    // additional information e.g. "P.O. BOX 168″" or apartment number
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string Country { get; set; }
    public int? PostalCode { get; set; }
    public string? State { get; set; }
    public bool IsPrimary { get; set; }
  }
}
