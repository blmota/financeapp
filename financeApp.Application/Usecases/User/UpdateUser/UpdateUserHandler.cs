using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.UpdateUser;

public class UpdateUserHandler(IUserRepository repository)
    : IRequestHandler<UpdateUserCommand, Result<UpdateUserResponse>>
{
    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var editUser = new UserEntity
        {
            Id = request.Id,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };
        
        var user = await repository.Update(editUser, cancellationToken);
        return user is null 
            ? Result.Failure<UpdateUserResponse>(new Error("400", "Não foi possível cadastrar o usuário.")) 
            : Result.Success(new UpdateUserResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}