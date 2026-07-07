using financeApp.Domain.Abstractions;

namespace financeApp.Domain.Entities;

public class UserEntity : Entity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } =  string.Empty;
    public string Email { get; set; } =  string.Empty;
    public string Password { get; set; } =  string.Empty;
    public int Level { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public string GetFullName()
    {
        return $"{FirstName} {LastName}";
    }
}