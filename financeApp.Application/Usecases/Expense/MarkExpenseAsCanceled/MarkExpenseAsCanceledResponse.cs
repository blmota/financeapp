using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsCanceled;

public class MarkExpenseAsCanceledResponse(
    int Id,
    string Title,
    int  Amount,
    DateTime DueDate,
    ExpenseStatusEnum Status,
    string Description,
    int CategoryId
    );