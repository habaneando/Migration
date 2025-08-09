namespace Migration.Common;

public abstract class BaseEntity<TId> : Entity<TId>, ITypedEntity
    where TId : IComparable<TId>
{
    protected BaseEntity(TId id) : base(id) { }
}
