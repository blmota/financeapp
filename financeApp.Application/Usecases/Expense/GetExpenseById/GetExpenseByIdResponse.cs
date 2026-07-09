using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Expense.GetExpenseById;

public class GetExpenseByIdResponse(
    int Id,
    string Title,
    int  Amount,
    DateOnly DueDate,
    ExpenseStatusEnum Status,
    string Description,
    int CategoryId
    );