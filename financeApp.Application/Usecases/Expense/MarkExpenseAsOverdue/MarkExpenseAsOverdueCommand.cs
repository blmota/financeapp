using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsOverdue;

public sealed record MarkExpenseAsOverdueCommand(
    int Id
    ) : IRequest<Result<MarkExpenseAsOverdueResponse>>;