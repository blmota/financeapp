using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using financeApp.Domain.ValueObjects;
using MediatR;

namespace financeApp.Application.Usecases.User.CreateUser;

public class CreateUserHandler(IUserRepository repository)
    : IRequestHandler<CreateUserCommand, Result<CreateUserResponse>>
{
    public async Task<Result<CreateUserResponse>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var newUser = new UserEntity
        {
            FirstName = new TextValueObject(value: request.FirstName, title: "Primeiro nome", isRequired: true),
            LastName = new TextValueObject(value: request.LastName, title: "Sobrenome", isRequired: true),
            Email = new EmailValueObject(request.Email)
        };
        
        newUser.SetPassword(request.Password);
        
        var user = await repository.Create(newUser, cancellationToken);
        return user is null 
            ? Result.Failure<CreateUserResponse>(new Error("400", "Não foi possível cadastrar o usuário.")) 
            : Result.Success(new CreateUserResponse(user.Id, user.GetFullName(), user.Email, user.Level, user.Status));
    }
}