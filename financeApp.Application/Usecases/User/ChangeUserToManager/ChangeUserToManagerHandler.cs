using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToManager;

public class ChangeUserToManagerHandler(IUserRepository repository)
: IRequestHandler<ChangeUserToManagerCommand, Result<ChangeUserToManagerResponse>>
{
    public async Task<Result<ChangeUserToManagerResponse>> Handle(ChangeUserToManagerCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeLevelTo(request.Id, UserLevelEnum.Manager, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserToManagerResponse>(new Error("400", "Não foi possível alterar o usuário para gerente.")) 
            : Result.Success(new ChangeUserToManagerResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}