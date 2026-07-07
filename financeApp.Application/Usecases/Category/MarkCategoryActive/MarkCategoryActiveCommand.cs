using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Category.MarkCategoryActive;

public sealed record MarkCategoryActiveCommand(
    int Id
    ) : IRequest<Result<MarkCategoryActiveResponse>>;