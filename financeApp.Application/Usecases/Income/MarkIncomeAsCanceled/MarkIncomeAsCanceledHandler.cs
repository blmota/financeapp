using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Income.MarkIncomeAsCanceled;

public class MarkIncomeAsCanceledHandler(IIncomeRepository repository)
: IRequestHandler<MarkIncomeAsCanceledCommand, Result<MarkIncomeAsCanceledResponse>>
{
    public async Task<Result<MarkIncomeAsCanceledResponse>> Handle(MarkIncomeAsCanceledCommand request,
        CancellationToken cancellationToken)
    {
        var income = await repository.GetById(request.Id, cancellationToken);
        income.Cancel();
        await repository.UpdateStatus(income, cancellationToken);
        return income is null 
            ? Result.Failure<MarkIncomeAsCanceledResponse>(new Error("400", "Não foi possível salvar cancelar receita.")) 
            : Result.Success(new MarkIncomeAsCanceledResponse(income.Id, income.Title.ToString()!, income.Description.ToString()!, income.Amount.Value, income.Date, income.Status));
    }
}