using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Income.GetIncomeById;

public class GetIncomeByIdHandler(IIncomeRepository repository)
: IRequestHandler<GetIncomeByIdCommand, Result<GetIncomeByIdResponse>>
{
    public async Task<Result<GetIncomeByIdResponse>> Handle(GetIncomeByIdCommand request,
        CancellationToken cancellationToken)
    {
        var income = await repository.GetById(request.Id, cancellationToken);
        return income is null 
            ? Result.Failure<GetIncomeByIdResponse>(new Error("404", "Usuário não encontrado.")) 
            : Result.Success(new GetIncomeByIdResponse(income.Id, income.Title, income.Description, income.Amount, income.Date, income.Status));
    }
}