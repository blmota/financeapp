using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.CreateUser;

public sealed record CreateUserCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    int Level,
    string Status
    ) : IRequest<Result<CreateUserResponse>>;