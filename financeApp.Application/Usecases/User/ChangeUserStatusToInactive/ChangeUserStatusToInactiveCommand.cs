using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToInactive;

public sealed record ChangeUserStatusToInactiveCommand(
    int Id
    ) : IRequest<Result<ChangeUserStatusToInactiveResponse>>;