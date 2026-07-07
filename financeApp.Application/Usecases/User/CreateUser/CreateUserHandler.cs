using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.User.CreateUser;

public class CreateUserHandler(IUserRepository repository)
    : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new UserEntity
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Level = request.Level,
            Status = request.Status
        };
        
        var user = await repository.Create(newUser, cancellationToken);
        return user is null 
            ? Result.Failure<CreateUserResponse>(new Error("400", "Não foi possível cadastrar o usuário.")) 
            : Result.Success(new CreateUserResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}