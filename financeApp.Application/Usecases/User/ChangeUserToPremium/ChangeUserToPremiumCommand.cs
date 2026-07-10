using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToPremium;

public sealed record ChangeUserToPremiumCommand(
    int Id
    ) : IRequest<Result<ChangeUserToPremiumResponse>>;