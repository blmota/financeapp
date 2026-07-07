using financeApp.Application.Usecases.Expense.GetExpenseById;
using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsCanceled;

public sealed record MarkExpenseAsCanceledCommand(
    int Id
    ) : IRequest<Result<MarkExpenseAsCanceledResponse>>;