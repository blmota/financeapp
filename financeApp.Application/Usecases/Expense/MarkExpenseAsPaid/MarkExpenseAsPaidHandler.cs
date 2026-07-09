using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsPaid;

public class MarkExpenseAsPaidHandler(IExpenseRepository repository)
: IRequestHandler<MarkExpenseAsPaidCommand, Result<MarkExpenseAsPaidResponse>>
{
    public async Task<Result<MarkExpenseAsPaidResponse>> Handle(MarkExpenseAsPaidCommand request,
        CancellationToken cancellationToken)
    {
        var expense = await repository.GetById(request.Id, cancellationToken);
        expense.MarkAsPaid();
        await repository.UpdateStatus(expense, cancellationToken);
        return expense is null
            ? Result.Failure<MarkExpenseAsPaidResponse>(new Error("400", "Não foi possível salvar despesa como paga.")) 
            : Result.Success(new MarkExpenseAsPaidResponse(expense.Id, expense.Title.ToString()!, expense.Amount.Value, expense.DueDate.Value, expense.Status, expense.Description.ToString()!, expense.CategoryId));
    }
}