using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToActive;

public class ChangeUserStatusToActiveHandler(IUserRepository repository)
: IRequestHandler<ChangeUserStatusToActiveCommand, Result<ChangeUserStatusToActiveResponse>>
{
    public async Task<Result<ChangeUserStatusToActiveResponse>> Handle(ChangeUserStatusToActiveCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeStatusTo(request.Id, UserStatusEnum.Active, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserStatusToActiveResponse>(new Error("400", "Não foi possível ativar o usuário.")) 
            : Result.Success(new ChangeUserStatusToActiveResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}