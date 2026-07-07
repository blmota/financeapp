using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Category.CreateCategory;

public class CreateCategoryHandler(ICategoryRepository repository)
: IRequestHandler<CreateCategoryCommand, Result<CreateCategoryResponse>>
{
    public async Task<Result<CreateCategoryResponse>> Handle(CreateCategoryCommand request,
        CancellationToken cancellationToken)
    {
        var newCategory = new CategoryEntity(request.Title);
        var category = await repository.Create(newCategory, cancellationToken);
        return category == null
            ? Result.Failure<CreateCategoryResponse>(new Error("400", "Não foi possível cadastrar a categoria.")) 
            : Result.Success(new CreateCategoryResponse(category.Id, category.Title, category.Status));
    }
}