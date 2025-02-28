namespace HouseRentals.Core.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() { }

    public long Id { get; protected set; }
}
