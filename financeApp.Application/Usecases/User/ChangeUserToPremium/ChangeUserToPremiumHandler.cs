using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.ChangeUserToPremium;

public class ChangeUserToPremiumHandler(IUserRepository repository)
: IRequestHandler<ChangeUserToPremiumCommand, Result<ChangeUserToPremiumResponse>>
{
    public async Task<Result<ChangeUserToPremiumResponse>> Handle(ChangeUserToPremiumCommand request,
        CancellationToken cancellationToken)
    {
        var user = await repository.ChangeLevelTo(request.Id, UserLevelEnum.Premium, cancellationToken);
        return user is null 
            ? Result.Failure<ChangeUserToPremiumResponse>(new Error("400", "Não foi possível ativar o plano premium para o usuário.")) 
            : Result.Success(new ChangeUserToPremiumResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}