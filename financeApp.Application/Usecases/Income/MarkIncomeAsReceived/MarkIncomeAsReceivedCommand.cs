using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Income.MarkIncomeAsReceived;

public sealed record MarkIncomeAsReceivedCommand(
    int Id
    ) : IRequest<Result<MarkIncomeAsReceivedResponse>>;