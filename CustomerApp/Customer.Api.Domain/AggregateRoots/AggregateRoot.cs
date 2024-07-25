using Customer.Api.Domain.Primitives;

namespace Customer.Api.Domain.AggregateRoots
{
    public abstract class AggregateRoot(Guid id) : EntityBase(id);
}
