using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;

namespace financeApp.Domain.Entities;

public class IncomeEntity : Entity
{
    public int UserId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public int CategoryId { get; private set; }
    public int Amount { get; private set; }
    public DateTime Date { get; private set; }
    public IncomeStatusEnum Status { get; private set; }

    public IncomeEntity(
        int  userId,
        string title,
        string description,
        int categoryId,
        int amount,
        DateTime date)
    {
        UserId = userId;
        Title = title.Trim();
        Description = description.Trim();
        CategoryId = categoryId;
        Amount = amount;
        Status = IncomeStatusEnum.Pending;
    }
    
    public void MarkAsRecieved()
    {
        Status = IncomeStatusEnum.Received;
    }
    
    public void Cancel()
    {
        Status = IncomeStatusEnum.Cancelled;
    }
}