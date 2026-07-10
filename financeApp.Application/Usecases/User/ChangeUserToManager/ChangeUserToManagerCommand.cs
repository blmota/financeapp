using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToManager;

public sealed record ChangeUserToManagerCommand(
    int Id
    ) : IRequest<Result<ChangeUserToManagerResponse>>;