using financeApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace financeApp.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<UserEntity> Users { get; set; } = null!;
    public DbSet<IncomeEntity> Income { get; set; } = null!;
    public DbSet<ExpenseEntity> Expense { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DependencyInjection).Assembly);
    }
}