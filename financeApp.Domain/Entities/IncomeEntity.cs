using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.ValueObjects;

namespace financeApp.Domain.Entities;

public class IncomeEntity : Entity
{
    public int UserId { get; private set; }
    public TextValueObject Title { get; private set; }
    public TextValueObject Description { get; private set; }
    public int CategoryId { get; private set; }
    public MoneyValueObject Amount { get; private set; }
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
        Title = new TextValueObject(value: title.Trim(), isRequired: true);
        Description = new TextValueObject(value: description.Trim(), title: "Descrição", limit: 1000, isRequired: true);
        CategoryId = categoryId;
        Amount = new MoneyValueObject(amount);
        Status = IncomeStatusEnum.Pending;
    }
    
    public void MarkAsRecieved()
    {
        if (Status == IncomeStatusEnum.Received)
            throw new InvalidOperationException("A receita já foi recebida anteriormente.");
        
        if (Status == IncomeStatusEnum.Cancelled)
            throw new InvalidOperationException("Uma receita cancelada não pode ter seu status alterado.");
        
        Status = IncomeStatusEnum.Received;
    }
    
    public void Cancel()
    {
        if (Status == IncomeStatusEnum.Cancelled)
            throw new InvalidOperationException("A receita já foi cancelada anteriormente.");
        
        if (Status == IncomeStatusEnum.Received)
            throw new InvalidOperationException("Uma receita recebida não pode ter seu status alterado.");
        
        Status = IncomeStatusEnum.Cancelled;
    }
}