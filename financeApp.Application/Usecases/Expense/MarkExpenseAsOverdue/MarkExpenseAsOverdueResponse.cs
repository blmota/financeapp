using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsOverdue;

public class MarkExpenseAsOverdueResponse(
    int Id,
    string Title,
    int  Amount,
    DateTime DueDate,
    ExpenseStatusEnum Status,
    string Description,
    int CategoryId
    );