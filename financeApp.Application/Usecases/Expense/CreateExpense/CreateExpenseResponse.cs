using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Expense.CreateExpense;

public class CreateExpenseResponse(
    int Id,
    string Title,
    int  Amount,
    DateOnly DueDate,
    ExpenseStatusEnum Status,
    string Description,
    int CategoryId
    );