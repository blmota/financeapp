using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using financeApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace financeApp.Infrastructure.Repositories;

public class CategoryRepository(AppDbContext context) : ICategoryRepository
{
    public async Task<CategoryEntity?> GetById(int id, CancellationToken cancellationToken)
    => await context.Categories.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<CategoryEntity> Create(CategoryEntity entity, CancellationToken cancellationToken = default)
    {
        await context.Categories.AddAsync(entity, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<CategoryEntity> UpdateStatus(CategoryEntity entity,
        CancellationToken cancellationToken = default)
    {
        var category = await GetById(entity.Id, cancellationToken);
        
        if (category == null)
            throw new Exception("A categoria não existe ou foi removida recentemente.");
        
        context.Categories.Update(entity);
        await context.SaveChangesAsync(cancellationToken);
        return entity;
    }
    
}