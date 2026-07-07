using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.GetById;

public sealed class GetUserByIdHandler(IUserRepository repository)
: IRequestHandler<GetUserByIdCommand, Result<GetUserByIdResponse>>
{
    public async Task<Result<GetUserByIdResponse>> Handle(GetUserByIdCommand request, CancellationToken cancellationToken)
    {
        var user = await repository.GetById(request.id, cancellationToken);
        return user is null 
            ? Result.Failure<GetUserByIdResponse>(new Error("404", "Usuário não encontrado.")) 
            : Result.Success(new GetUserByIdResponse(user.Id, user.GetFullName()));
    }
}