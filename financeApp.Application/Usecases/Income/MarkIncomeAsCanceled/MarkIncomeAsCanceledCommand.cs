using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Income.MarkIncomeAsCanceled;

public sealed record MarkIncomeAsCanceledCommand(
    int Id
    ) : IRequest<Result<MarkIncomeAsCanceledResponse>>;