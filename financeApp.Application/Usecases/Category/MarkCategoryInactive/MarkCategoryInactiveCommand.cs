using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Category.MarkCategoryInactive;

public sealed record MarkCategoryInactiveCommand(
    int Id
    ) : IRequest<Result<MarkCategoryInactiveResponse>>;