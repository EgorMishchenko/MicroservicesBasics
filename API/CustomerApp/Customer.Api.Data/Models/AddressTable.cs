namespace Customer.Api.Data.Models
{
  public class AddressTable
  {
    public int AddressId { get; set; }
    public string AddressLine1 { get; set; }
    public string? AddressLine2 { get; set; }
    public string? City { get; set; }
    public string Country { get; set; }
    public int? PostalCode { get; set; }
    public string? State { get; set; }
    public bool IsPrimary { get; set; }
  }
}
