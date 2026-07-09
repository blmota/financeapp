using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.ValueObjects;
using financeApp.Domain.ValueObjects.Expense;
using Microsoft.VisualBasic;

namespace financeApp.Domain.Entities;

public class ExpenseEntity : Entity
{
    public int UserId { get; private set; }
    public ExpenseTitleValueObject Title { get; private set; }
    public MoneyValueObject Amount { get; private set; }
    public DueDateValueObject DueDate { get; private set; }
    public ExpenseStatusEnum Status { get; private set; }
    public TextValueObject? Description { get; private set; }
    public int CategoryId { get; private set; }
    
    public ExpenseEntity(
        int userId,
        string title,
        int amount,
        DateOnly dueDate,
        int categoryId,
        string? description = null)
    {
        UserId = userId;
        Title = new ExpenseTitleValueObject(title);
        Amount = new MoneyValueObject(amount);
        DueDate = new DueDateValueObject(dueDate);
        CategoryId = categoryId;
        Description = new TextValueObject(value: description, title: "Descrição", limit: 1000, isRequired: true);
        Status = ExpenseStatusEnum.Pending;
    }

    public void MarkAsPaid()
    {
        if (Status == ExpenseStatusEnum.Cancelled)
            throw new InvalidOperationException("Uma despesa cancelada não pode ter seu status alterado.");
        
        Status = ExpenseStatusEnum.Paid;
    }

    public void Cancel()
    {
        if (Status == ExpenseStatusEnum.Paid)
            throw new InvalidOperationException("Uma despesa paga não pode ter seu status alterado.");
        
        Status = ExpenseStatusEnum.Cancelled;
    }

    public void Overdue()
    {
        if (Status == ExpenseStatusEnum.Paid)
            throw new InvalidOperationException("Uma despesa paga não pode ter seu status alterado.");
        
        Status = ExpenseStatusEnum.Overdue;
    }
}