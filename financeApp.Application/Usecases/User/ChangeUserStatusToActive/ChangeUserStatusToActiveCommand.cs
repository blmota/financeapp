using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToActive;

public sealed record ChangeUserStatusToActiveCommand(
    int Id
    ) : IRequest<Result<ChangeUserStatusToActiveResponse>>;