using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsPaid;

public sealed record MarkExpenseAsPaidCommand(
    int Id
    ) : IRequest<Result<MarkExpenseAsPaidResponse>>;