using financeApp.Domain.Abstractions;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Expense.GetExpenseById;

public class GetExpenseByIdHandler(IExpenseRepository repository)
: IRequestHandler<GetExpenseByIdCommand, Result<GetExpenseByIdResponse>>
{
    public async Task<Result<GetExpenseByIdResponse>> Handle(GetExpenseByIdCommand request,
        CancellationToken cancellationToken)
    {
        var expense = await repository.GetById(request.Id, cancellationToken);
        return expense is null 
            ? Result.Failure<GetExpenseByIdResponse>(new Error("404", "Despesa não existe ou foi removido recentemente.")) 
            : Result.Success(new GetExpenseByIdResponse(expense.Id, expense.Title.ToString()!, expense.Amount.Value, expense.DueDate.Value, expense.Status, expense.Description.ToString()!, expense.CategoryId));
    }
}