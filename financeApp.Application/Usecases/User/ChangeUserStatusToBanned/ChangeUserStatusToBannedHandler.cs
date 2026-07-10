using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserStatusToBanned;

public class ChangeUserStatusToBannedHandler(IUserRepository repository)
: IRequestHandler<ChangeUserStatusToBannedCommand, Result<ChangeUserStatusToBannedResponse>>
{
    public async Task<Result<ChangeUserStatusToBannedResponse>> Handle(ChangeUserStatusToBannedCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeStatusTo(request.Id, UserStatusEnum.Banned, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserStatusToBannedResponse>(new Error("400", "Não foi possível banir o usuário.")) 
            : Result.Success(new ChangeUserStatusToBannedResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}