using financeApp.Domain.Entities;
using financeApp.Domain.Enums;
using financeApp.Domain.Repositories;
using financeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace financeApp.Infrastructure.Repositories;

public class UserRepository(AppDbContext context) : IUserRepository
{
    public async Task<UserEntity?> GetById(int id,  CancellationToken cancellationToken)
        => await context.Users.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    
    public async Task<UserEntity?> GetByEmail(string email,  CancellationToken cancellationToken)
        => await context.Users.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);

    public async Task<UserEntity> Create(UserEntity entity, CancellationToken cancellationToken)
    {
        var emailExists = await GetByEmail(entity.Email, cancellationToken);
        
        if (emailExists != null)
            throw new Exception("O E-mail informado já possui cadastro.");
        
        await context.Users.AddAsync(entity,  cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<UserEntity> Update(UserEntity entity, CancellationToken cancellationToken)
    {
        var user = await GetById(entity.Id, cancellationToken);

        if (user == null)
            throw new Exception("O usuário não existe ou foi removido recentemente.");
        
        user.NewFirstName(entity.FirstName.ToString()!);
        user.NewLastName(entity.LastName.ToString()!);
        user.Email = entity.Email;

        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return user;
    }

    public async Task<bool> Delete(int id, CancellationToken cancellationToken)
    {
        var user = await GetById(id, cancellationToken);
        
        if (user == null)
            throw new Exception("O usuário não existe ou foi removido recentemente.");

        context.Users.Remove(user);
        await context.SaveChangesAsync(cancellationToken);
        return true;
    }

    public async Task<UserEntity> ChangeLevelTo(int id, UserLevelEnum level, CancellationToken cancellationToken = default)
    {
        var user = await GetById(id, cancellationToken);

        if (user == null)
            throw new Exception("O usuário não existe ou foi removido recentemente.");
        
        user.ChangeLevelTo(level);

        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return user;
    }

    public async Task<UserEntity> ChangeStatusTo(int id, UserStatusEnum status, CancellationToken cancellationToken = default)
    {
        var user = await GetById(id, cancellationToken);

        if (user == null)
            throw new Exception("O usuário não existe ou foi removido recentemente.");
        
        user.ChangeStatusTo(status);

        context.Users.Update(user);
        await context.SaveChangesAsync(cancellationToken);
        
        return user;
    }
}