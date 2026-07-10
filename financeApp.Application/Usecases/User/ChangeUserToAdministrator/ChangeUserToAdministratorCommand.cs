using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToAdministrator;

public sealed record ChangeUserToAdministratorCommand(
    int Id
    ) :  IRequest<Result<ChangeUserToAdministratorResponse>>;