using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Expense.GetExpenseById;

public sealed record GetExpenseByIdCommand(
    int Id
    ) : IRequest<Result<GetExpenseByIdResponse>>;