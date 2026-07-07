using financeApp.Domain.Abstractions;
using MediatR;

namespace financeApp.Application.Usecases.Category.CreateCategory;

public sealed record CreateCategoryCommand(
    string Title
    ) :  IRequest<Result<CreateCategoryResponse>>;