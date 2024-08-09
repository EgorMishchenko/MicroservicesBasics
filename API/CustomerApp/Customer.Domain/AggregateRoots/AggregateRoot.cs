using Customer.Domain.Primitives;

namespace Customer.Domain.AggregateRoots
{
  public abstract class AggregateRoot(Guid id) : EntityBase(id)
  {
    private readonly List<IDomainEvent> _domainEvents = new();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
      _domainEvents.Add(domainEvent);
    }
  }
}
