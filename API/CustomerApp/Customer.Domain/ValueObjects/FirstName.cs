using Customer.Domain.Primitives;

namespace Customer.Domain.ValueObjects
{
  // can be replaced with record struct ?
  public sealed class FirstName : ValueObject
  {
    public const int MaxLength = 50;

    private FirstName(string value)
    {
        // exception in ctor is bad, so move it to method
      Value = value;
    }

    public string Value { get; }

    public static FirstName Create(string firstName)
    {
      // todo: replace with result object
      if (string.IsNullOrWhiteSpace(firstName))
      {
          throw new ArgumentException("First name is empty or white space");
      }

      if (firstName.Length > MaxLength)
      {
          throw new ArgumentException("Length is too long"); 
      }

      return new FirstName(firstName);
    }

    public override IEnumerable<object> GetAtomicValues()
    {
      yield return Value;
    }
  }
}
