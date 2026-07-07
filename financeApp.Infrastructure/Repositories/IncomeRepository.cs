using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using financeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace financeApp.Infrastructure.Repositories;

public class IncomeRepository(AppDbContext context) : IIncomeRepository
{
    public async Task<IncomeEntity?> GetById(int id, CancellationToken cancellationToken)
    => await context.Income.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<IncomeEntity> Create(IncomeEntity entity, CancellationToken cancellationToken = default)
    {
        await context.Income.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<IncomeEntity> UpdateStatus(IncomeEntity entity, CancellationToken cancellationToken = default)
    {
        var income = await GetById(entity.Id, cancellationToken);
        
        if (income == null)
            throw new Exception("A receita não existe ou foi removida recentemente.");
        
        context.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
}