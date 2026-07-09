using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Income.MarkIncomeAsReceived;

public class MarkIncomeAsReceivedHandler(IIncomeRepository repository)
: IRequestHandler<MarkIncomeAsReceivedCommand, Result<MarkIncomeAsReceivedResponse>>
{
    public async Task<Result<MarkIncomeAsReceivedResponse>> Handle(MarkIncomeAsReceivedCommand request,
        CancellationToken cancellationToken)
    {
        var income = await repository.GetById(request.Id, cancellationToken);
        income.MarkAsRecieved();
        await repository.UpdateStatus(income, cancellationToken);
        return income is null 
            ? Result.Failure<MarkIncomeAsReceivedResponse>(new Error("400", "Não foi possível salvar receita como recebida.")) 
            : Result.Success(new MarkIncomeAsReceivedResponse(income.Id, income.Title.ToString()!, income.Description.ToString()!, income.Amount.Value, income.Date, income.Status));
    }
}