namespace Customer.Domain.Primitives
{
    public abstract class EntityBase : IEquatable<EntityBase>
    {
        protected internal EntityBase(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private init; }

        public static bool operator ==(EntityBase? first, EntityBase? second)
        {
            return first is not null && second is not null && first.Equals(second);
        }

        public static bool operator !=(EntityBase? first, EntityBase? second)
        {
            return !(first == second);
        }

        public bool Equals(EntityBase? other)
        {
            if (other is null) return false;
            if (other.GetType() != this.GetType()) return false;
            return other.Id == Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != this.GetType()) return false;
            if (obj is not EntityBase entity) return false;
            return entity.Id == Id;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode() + 41;
        }
    }
}
