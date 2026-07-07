using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using MediatR;

namespace financeApp.Application.Usecases.Expense.CreateExpense;

public sealed record CreateExpenseCommand(
    int UserId,
    string Title,
    int Amount,
    DateTime DueDate,
    string Description,
    int CategoryId
    ) : IRequest<Result<CreateExpenseResponse>>;