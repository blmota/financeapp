using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToInactive;

public class ChangeUserStatusToInactiveHandler(IUserRepository repository)
: IRequestHandler<ChangeUserStatusToInactiveCommand, Result<ChangeUserStatusToInactiveResponse>>
{
    public async Task<Result<ChangeUserStatusToInactiveResponse>> Handle(ChangeUserStatusToInactiveCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeStatusTo(request.Id, UserStatusEnum.Inactive, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserStatusToInactiveResponse>(new Error("400", "Não foi possível inativar o usuário.")) 
            : Result.Success(new ChangeUserStatusToInactiveResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}