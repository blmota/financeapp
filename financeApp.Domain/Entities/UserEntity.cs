using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.ValueObjects;

namespace financeApp.Domain.Entities;

public class UserEntity : Entity
{
    public TextValueObject FirstName { get; set; }
    public TextValueObject LastName { get; set; }
    public EmailValueObject Email { get; set; }
    public PasswordValueObject Password { get; set; }
    public UserLevelEnum Level { get; private set; }
    public UserStatusEnum Status { get; private set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public UserEntity()
    {
        Level = UserLevelEnum.Client;
        Status = UserStatusEnum.Registered;
    }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }

    public void NewFirstName(string firstName)
    {
        FirstName = new TextValueObject(value: firstName, title: "Primeiro nome", isRequired: true);
    }

    public void NewLastName(string lastName)
    {
        LastName = new TextValueObject(value: lastName, title: "Sobrenome", isRequired: true);
    }

    public void SetPassword(string password)
    {
        Password = new PasswordValueObject(password);
    }

    public void ToPremium()
    {
        Level = UserLevelEnum.Premium;
    }

    public void ToManager()
    {
        Level = UserLevelEnum.Manager;
    }

    public void ToAdministrator()
    {
        Level = UserLevelEnum.Administrator;
    }

    public void ChangeToActive()
    {
        Status = UserStatusEnum.Active;
    }
    
    public void ChangeToInactive()
    {
        Status = UserStatusEnum.Inactive;
    }

    public void ChangeToBanned()
    {
        Status = UserStatusEnum.Banned;
    }
}