using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.DeleteUser;

public sealed record DeleteUserCommand(int id) : IRequest<Result<DeleteUserResponse>>;