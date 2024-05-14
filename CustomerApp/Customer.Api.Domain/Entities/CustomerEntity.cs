using Customer.Api.Domain.Primitives;
using Customer.Api.Domain.ValueObjects;

namespace Customer.Api.Domain.Entities
{
    public sealed class CustomerEntity : EntityBase
    {
        public CustomerEntity(
            CustomerId id,
            FirstName firstName,
            LastName lastName,
            DateOnly birthday) :
            base(id.Value)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthday = birthday;
        }

        public FirstName FirstName { get; init; }
        public LastName LastName { get; init; }
        public DateOnly? Birthday { get; init; }
    }
}
