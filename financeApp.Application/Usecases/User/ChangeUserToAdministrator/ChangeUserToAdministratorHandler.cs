using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToAdministrator;

public class ChangeUserToAdministratorHandler(IUserRepository repository)
: IRequestHandler<ChangeUserToAdministratorCommand, Result<ChangeUserToAdministratorResponse>>
{
    public async Task<Result<ChangeUserToAdministratorResponse>> Handle(ChangeUserToAdministratorCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeLevelTo(request.Id, UserLevelEnum.Administrator, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserToAdministratorResponse>(new Error("400", "Não foi possível alterar o usuário para administrador.")) 
            : Result.Success(new ChangeUserToAdministratorResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}