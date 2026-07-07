using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Category.GetCategoryById;

public sealed record GetCategoryByIdCommand(
    int Id
    ) : IRequest<Result<GetCategoryByIdResponse>>;