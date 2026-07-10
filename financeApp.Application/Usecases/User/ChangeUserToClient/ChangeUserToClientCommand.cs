using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToClient;

public sealed record ChangeUserToClientCommand(
    int Id
    ) : IRequest<Result<ChangeUserToClientResponse>>;