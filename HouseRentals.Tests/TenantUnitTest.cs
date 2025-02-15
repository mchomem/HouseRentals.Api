namespace HouseRentals.Tests;

public class TenantUnitTest
{
    [Fact]
    public void Constructor_Tenant_ReturnTenant()
    {
        // Arrange
        var fullName = "Mike Billy";
        var email = "mike.billy@email.com";
        var phoneNumber = "51999999999";
        var birthDate = DateTime.Today.AddYears(-20);

        // Act
        var tenant = new Tenant(fullName, email, phoneNumber, birthDate);

        // Assert
        Assert.Equal(fullName, tenant.FullName);
        Assert.Equal(email, tenant.Email);
        Assert.Equal(phoneNumber, tenant.PhoneNumber);
        Assert.Equal(birthDate, tenant.BirthDate);
        Assert.False(tenant.Deleted);
        Assert.NotNull(tenant);
    }

    [Fact]
    public void Update_Tenant_ReturnTenant()
    {
        // Arrange
        var tenant = new Tenant("John Doe", "old@email.com", "1234567890", DateTime.Today.AddYears(-20));
        var newFullName = "Jane Doe";
        var newEmail = "janedoe@email.com";
        var newPhoneNumber = "0987654321";
        DateTime newBirthDate = DateTime.Today.AddYears(-25);

        // Act
        tenant.Update(newFullName, newEmail, newPhoneNumber, newBirthDate);

        // Assert
        Assert.Equal(newFullName, tenant.FullName);
        Assert.Equal(newEmail, tenant.Email);
        Assert.Equal(newPhoneNumber, tenant.PhoneNumber);
        Assert.Equal(newBirthDate, tenant.BirthDate);
    }

    [Fact]
    public void Delete_Tenant_ShouldMarkAsDeleted()
    {
        // Arrange
        var tenant = new Tenant("John Doe", "johndoe@email.com", "1234567890", DateTime.Today.AddYears(-20));

        // Act
        tenant.Delete();

        // Assert
        Assert.True(tenant.Deleted);
    }

    [Fact]
    public void CreateTenant_WithUnderageBirthDate_ShouldThrowException()
    {
        // Arrange
        DateTime underageBirthDate = DateTime.Today.AddYears(-17);

        // Act & Assert
        var exception = Assert.Throws<TenantException>(() =>
            new Tenant("John Doe", "johndoe@email.com", "1234567890", underageBirthDate));
        Assert.Equal(DefaultMessages.TenantMustBeAtLeast18YearsOld, exception.Message);
    }

    [Fact]
    public void UpdateTenant_WithUnderageBirthDate_ShouldThrowException()
    {
        // Arrange
        var tenant = new Tenant("John Doe", "johndoe@email.com", "1234567890", DateTime.Today.AddYears(-20));
        DateTime underageBirthDate = DateTime.Today.AddYears(-17);

        // Act & Assert
        var exception = Assert.Throws<TenantException>(() =>
            tenant.Update("John Doe", "johndoe@email.com", "1234567890", underageBirthDate));
        Assert.Equal(DefaultMessages.TenantMustBeAtLeast18YearsOld, exception.Message);
    }
}
