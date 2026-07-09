using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Expense.MarkExpenseAsOverdue;

public class MarkExpenseAsOverdueHandler(IExpenseRepository repository)
: IRequestHandler<MarkExpenseAsOverdueCommand, Result<MarkExpenseAsOverdueResponse>>
{
    public async Task<Result<MarkExpenseAsOverdueResponse>> Handle(MarkExpenseAsOverdueCommand request,
        CancellationToken cancellationToken)
    {
        var expense = await repository.GetById(request.Id, cancellationToken);
        expense.Overdue();
        return expense is null
            ? Result.Failure<MarkExpenseAsOverdueResponse>(new Error("400", "Não foi possível salvar despesa como vencida.")) 
            : Result.Success(new MarkExpenseAsOverdueResponse(expense.Id, expense.Title.ToString()!, expense.Amount.Value, expense.DueDate.Value, expense.Status, expense.Description.ToString()!, expense.CategoryId));
    }
}