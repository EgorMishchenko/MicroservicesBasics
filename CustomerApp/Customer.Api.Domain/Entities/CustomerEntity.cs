using Customer.Api.Domain.AggregateRoots;
using Customer.Api.Domain.ValueObjects;

namespace Customer.Api.Domain.Entities
{
  public sealed class CustomerEntity : AggregateRoot
  {
    private readonly List<AddressEntity> _addresses = new();

    public CustomerEntity(CustomerId id,
      FirstName firstName,
      LastName lastName,
      DateOnly? birthday,
      string? email,
      IEnumerable<AddressEntity> addresses) : base(id.Value)
    {
      FirstName = firstName;
      LastName = lastName;
      Birthday = birthday;
      Email = email;
      _addresses = addresses.ToList();
    }

    public FirstName FirstName { get; init; }
    public LastName LastName { get; init; }
    public DateOnly? Birthday { get; init; }
    public string? Email { get; set; }

    public IReadOnlyCollection<AddressEntity> Addresses => _addresses.AsReadOnly();
    public void AddAddress(AddressEntity address) => _addresses.Add(address);
    public void UpdateAddress(AddressEntity newAddress, int addressId)
    {
      var existingAddress = _addresses.FirstOrDefault(address => address.AddressId == addressId);

      if (existingAddress == null)
      {
        throw new ArgumentException("Cannot find address.");
      }

      existingAddress.AddressLine1 = newAddress.AddressLine1;
      existingAddress.AddressLine2 = newAddress.AddressLine2;
      existingAddress.City = newAddress.City;
      existingAddress.Country = newAddress.Country;
      existingAddress.PostalCode = newAddress.PostalCode;
      existingAddress.State = newAddress.State;

      if (existingAddress.IsPrimary == true && newAddress.IsPrimary == false)
      {
        throw new ArgumentException("It's required to have at least 1 primary address");
      }

      if (existingAddress.IsPrimary == false && newAddress.IsPrimary == true)
      {
        foreach (var address in _addresses)
        {
          if (address.AddressId != addressId)
          {
            address.IsPrimary = false;
          }
        }

        existingAddress.IsPrimary = true;
      }
    }

    public void DeleteAddress(int addressId)
    {
      var address = _addresses.FirstOrDefault(x => x.AddressId == addressId);
      if (address == null)
      {
        throw new ArgumentException($"Cannot find Address with Id: {addressId}");
      }

      _addresses.Remove(address);
    }
  }
}
