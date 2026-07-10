using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToBanned;

public sealed record ChangeUserStatusToBannedCommand(
    int Id
    ) : IRequest<Result<ChangeUserStatusToBannedResponse>>;