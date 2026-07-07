using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using MediatR;

namespace financeApp.Application.Usecases.Income.CreateIncome;

public sealed record CreateIncomeCommand(
    int UserId,
    string Title,
    string Description,
    int CategoryId,
    int Amount,
    DateTime Date,
    IncomeStatusEnum IncomeStatus
    ) : IRequest<Result<CreateIncomeResponse>>;