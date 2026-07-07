using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Income.GetIncomeById;

public sealed record GetIncomeByIdCommand(
    int Id
    ) : IRequest<Result<GetIncomeByIdResponse>>;