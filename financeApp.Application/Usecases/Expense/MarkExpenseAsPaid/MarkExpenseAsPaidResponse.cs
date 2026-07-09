using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsPaid;

public class MarkExpenseAsPaidResponse(
    int Id,
    string Title,
    int  Amount,
    DateOnly DueDate,
    ExpenseStatusEnum Status,
    string Description,
    int CategoryId
    );