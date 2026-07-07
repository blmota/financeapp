using financeApp.Domain.Entities;

namespace financeApp.Domain.Repositories;

public interface ICategoryRepository
{
    public Task<CategoryEntity?> GetById(int id, CancellationToken cancellationToken);
    public Task<CategoryEntity> Create(CategoryEntity entity, CancellationToken cancellationToken = default);
    public Task<CategoryEntity> UpdateStatus(CategoryEntity entity, CancellationToken cancellationToken = default);
}