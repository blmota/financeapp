using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using financeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace financeApp.Infrastructure.Repositories;

public class ExpenseRepository(AppDbContext context) : IExpenseRepository
{
    public async Task<ExpenseEntity?> GetById(int id, CancellationToken cancellationToken)
        => await context.Expense.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<ExpenseEntity> Create(ExpenseEntity entity, CancellationToken cancellationToken = default)
    {
        await context.Expense.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<ExpenseEntity> UpdateStatus(ExpenseEntity entity, CancellationToken cancellationToken = default)
    {
        var expense = await GetById(entity.Id, cancellationToken);
        
        if (expense == null)
            throw new Exception("A despesa não existe ou foi removida recentemente.");
        
        context.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}