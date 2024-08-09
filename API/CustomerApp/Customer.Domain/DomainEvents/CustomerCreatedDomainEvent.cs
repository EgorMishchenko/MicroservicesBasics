using Customer.Domain.Primitives;

namespace Customer.Domain.DomainEvents
{
  public sealed record CustomerCreatedDomainEvent() : IDomainEvent
  {
  }
}
