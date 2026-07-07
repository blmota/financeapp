using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.DeleteUser;

public sealed class DeleteUserHandler(IUserRepository repository)
: IRequestHandler<DeleteUserCommand, Result<DeleteUserResponse>>
{
    public async Task<Result<DeleteUserResponse>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await repository.Delete(request.id, cancellationToken);
        return Result.Success(new DeleteUserResponse(true));
    }
}