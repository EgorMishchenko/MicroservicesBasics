namespace Customer.Api.Domain.ValueObjects
{
    public readonly record struct CustomerId(Guid Value)
    {
        public static CustomerId Empty => new(Guid.Empty);
        public static CustomerId NewBookId => new(Guid.NewGuid());
    }
}
