using financeApp.Domain.Entities;

namespace financeApp.Domain.Repositories;

public interface IExpenseRepository : IRepository<ExpenseEntity>
{
    public Task<ExpenseEntity?> GetById(int id, CancellationToken cancellationToken);
    public Task<ExpenseEntity> Create(ExpenseEntity entity, CancellationToken cancellationToken = default);
    public Task<ExpenseEntity> UpdateStatus(ExpenseEntity entity, CancellationToken cancellationToken = default);
}