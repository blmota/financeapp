using financeApp.Domain.Entities;

namespace financeApp.Domain.Repositories;

public interface IIncomeRepository : IRepository<IncomeEntity>
{
    public Task<IncomeEntity?> GetById(int id, CancellationToken cancellationToken);
    public Task<IncomeEntity> Create(IncomeEntity entity, CancellationToken cancellationToken = default);
    public Task<IncomeEntity> UpdateStatus(IncomeEntity entity, CancellationToken cancellationToken = default);
}