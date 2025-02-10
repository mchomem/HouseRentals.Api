namespace HouseRentals.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() { }

    public long Id { get; protected set; }
}
