namespace HouseRentals.Domain.Entities;

/// <summary>
/// Representa um inquilino que aluga uma casa.
/// </summary>
public class Tenant : BaseEntity
{
    private Tenant() { }

    public Tenant(string fullName, string email, string phoneNumber, DateTime birthDate)
    {
        CheckIfMinor(birthDate);

        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

    public string FullName { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public DateTime BirthDate { get; private set; }
    public bool Deleted { get; private set; }

    public ICollection<Rental> Rentals { get; private set; }

    public void Update(string fullName, string email, string phoneNumber, DateTime birthDate)
    {
        CheckIfMinor(birthDate);

        FullName = fullName;
        Email = email;
        PhoneNumber = phoneNumber;
        BirthDate = birthDate;
    }

    public void Delete()
    {
        Deleted = true;
    }

    public void CheckIfMinor(DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
            age--;

        if (age < 18)
            throw new TenantMustBeAtLeast18YearsOldException();
    }
}
