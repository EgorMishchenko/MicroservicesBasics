using Customer.Api.Domain.Primitives;

namespace Customer.Api.Domain.AggregateRoot
{
    public abstract class AggregateRoot : EntityBase
    {
        protected AggregateRoot(Guid id) : base(id)
        {
            
        }
    }
}
