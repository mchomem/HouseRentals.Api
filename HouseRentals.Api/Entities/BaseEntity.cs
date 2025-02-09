namespace HouseRentals.Api.Entities;

public abstract class BaseEntity
{
    protected BaseEntity() { }

    public long Id { get; protected set; }
}
