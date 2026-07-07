using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.UpdateUser;

public sealed record UpdateUserCommand(
    int Id,
    string FirstName,
    string LastName,
    string Email) : IRequest<Result<UpdateUserResponse>>;