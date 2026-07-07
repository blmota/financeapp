using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Category.MarkCategoryActive;

public class MarkCategoryActiveHandler(ICategoryRepository repository)
: IRequestHandler<MarkCategoryActiveCommand, Result<MarkCategoryActiveResponse>>
{
    public async Task<Result<MarkCategoryActiveResponse>> Handle(MarkCategoryActiveCommand request,
        CancellationToken cancellationToken)
    {
        var category = await repository.GetById(request.Id, cancellationToken);
        category.Active();
        await repository.UpdateStatus(category, cancellationToken);
        return category is null
            ? Result.Failure<MarkCategoryActiveResponse>(new Error("400", "Não foi possível ativar a categoria.")) 
            : Result.Success(new MarkCategoryActiveResponse(category.Id, category.Title, category.Status));
    }
}