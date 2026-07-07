using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;

namespace financeApp.Domain.Entities;

public class ExpenseEntity : Entity
{
    public int UserId { get; private set; }
    public string Title { get; private set; }
    public int Amount { get; private set; }
    public DateTime DueDate { get; private set; }
    public ExpenseStatusEnum Status { get; private set; }
    public string? Description { get; private set; }
    public int CategoryId { get; private set; }
    
    public ExpenseEntity(
        int userId,
        string title,
        int amount,
        DateTime dueDate,
        int categoryId,
        string? description = null)
    {
        UserId = userId;
        Title = title;
        Amount = amount;
        DueDate = dueDate;
        CategoryId = categoryId;
        Description = description;
        Status = ExpenseStatusEnum.Pending;
    }

    public void MarkAsPaid()
    {
        Status = ExpenseStatusEnum.Paid;
    }

    public void Cancel()
    {
        Status = ExpenseStatusEnum.Cancelled;
    }

    public void Overdue()
    {
        Status = ExpenseStatusEnum.Overdue;
    }
}