using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsCanceled;

public class MarkExpenseAsCanceledHandler(IExpenseRepository repository)
: IRequestHandler<MarkExpenseAsCanceledCommand, Result<MarkExpenseAsCanceledResponse>>
{
    public async Task<Result<MarkExpenseAsCanceledResponse>> Handle(MarkExpenseAsCanceledCommand request,
        CancellationToken cancellationToken)
    {
        var expense = await repository.GetById(request.Id, cancellationToken);
        expense.Cancel();
        return expense is null
            ? Result.Failure<MarkExpenseAsCanceledResponse>(new Error("400", "Não foi possível cancelar despesa.")) 
            : Result.Success(new MarkExpenseAsCanceledResponse(expense.Id, expense.Title, expense.Amount, expense.DueDate, expense.Status, expense.Description, expense.CategoryId));
    }
}