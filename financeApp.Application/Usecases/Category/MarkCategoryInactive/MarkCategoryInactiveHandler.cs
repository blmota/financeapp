using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Category.MarkCategoryInactive;

public class MarkCategoryInactiveHandler(ICategoryRepository repository)
: IRequestHandler<MarkCategoryInactiveCommand, Result<MarkCategoryInactiveResponse>>
{
    public async Task<Result<MarkCategoryInactiveResponse>> Handle(MarkCategoryInactiveCommand request,
        CancellationToken cancellationToken)
    {
        var category = await repository.GetById(request.Id, cancellationToken);
        category.Inactive();
        await repository.UpdateStatus(category, cancellationToken);
        return category is null
            ? Result.Failure<MarkCategoryInactiveResponse>(new Error("400", "Não foi possível inativar a categoria.")) 
            : Result.Success(new MarkCategoryInactiveResponse(category.Id, category.Title, category.Status));
    }
}