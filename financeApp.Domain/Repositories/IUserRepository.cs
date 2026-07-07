using financeApp.Domain.Entities;

namespace financeApp.Domain.Repositories;

public interface IUserRepository : IRepository<UserEntity>
{
    public Task<UserEntity?> GetById(int id, CancellationToken cancellationToken =  default);
    public Task<UserEntity?> GetByEmail(string email, CancellationToken cancellationToken =  default);
    public Task<UserEntity> Create(UserEntity entity, CancellationToken cancellationToken = default);
    public Task<UserEntity> Update(UserEntity entity, CancellationToken cancellationToken = default);
    public Task<bool> Delete(int id, CancellationToken cancellationToken = default);
}