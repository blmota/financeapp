using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Income.CreateIncome;

public class CreateIncomeHandler(IIncomeRepository repository)
: IRequestHandler<CreateIncomeCommand, Result<CreateIncomeResponse>>
{
    public async Task<Result<CreateIncomeResponse>> Handle(CreateIncomeCommand request,
        CancellationToken cancellationToken)
    {
        var newIncome = new IncomeEntity(
            request.UserId,
            request.Title,
            request.Description,
            request.CategoryId,
            request.Amount,
            request.Date);

        var income = await repository.Create(newIncome, cancellationToken);
        return income is null
            ? Result.Failure<CreateIncomeResponse>(new Error("400", "Não foi possível cadastrar a receita.")) 
            : Result.Success(new CreateIncomeResponse(income.Id, income.Title.ToString()!, income.Description.ToString()!, income.Amount.Value, income.Date, income.Status));
    }
}