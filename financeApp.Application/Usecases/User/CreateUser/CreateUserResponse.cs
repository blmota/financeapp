namespace financeApp.Application.Usecases.User.CreateUser;

public sealed record CreateUserResponse(
    int Id,
    string FullName,
    string Email,
    int Level,
    string Status);