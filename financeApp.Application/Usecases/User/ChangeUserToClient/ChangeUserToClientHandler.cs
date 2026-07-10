using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToClient;

public class ChangeUserToClientHandler(IUserRepository repository)
: IRequestHandler<ChangeUserToClientCommand, Result<ChangeUserToClientResponse>>
{
    public async Task<Result<ChangeUserToClientResponse>> Handle(ChangeUserToClientCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeLevelTo(request.Id, UserLevelEnum.Client, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserToClientResponse>(new Error("400", "Não foi possível alterar o usuário para cliente.")) 
            : Result.Success(new ChangeUserToClientResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}