using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Category.GetCategoryById;

public class GetCategoryByIdHandler(ICategoryRepository repository)
: IRequestHandler<GetCategoryByIdCommand, Result<GetCategoryByIdResponse>>
{
    public async Task<Result<GetCategoryByIdResponse>> Handle(GetCategoryByIdCommand request,
        CancellationToken cancellationToken)
    {
        var category = await repository.GetById(request.Id, cancellationToken);
        return category == null
            ? Result.Failure<GetCategoryByIdResponse>(new Error("404", "Categoria não encontrada.")) 
            : Result.Success(new GetCategoryByIdResponse(category.Id, category.Title.ToString()!, category.Status));
    }
}