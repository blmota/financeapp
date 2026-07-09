using financeApp.Domain.Abstractions;
using financeApp.Domain.Entities;
using financeApp.Domain.Repositories;
using MediatR;

namespace financeApp.Application.Usecases.Expense.CreateExpense;

public class CreateExpenseHandler(IExpenseRepository repository)
: IRequestHandler<CreateExpenseCommand, Result<CreateExpenseResponse>>
{
    public async Task<Result<CreateExpenseResponse>> Handle(CreateExpenseCommand request,
        CancellationToken cancellationToken)
    {
        var newExpense = new ExpenseEntity(
            request.UserId,
            request.Title,
            request.Amount,
            request.DueDate,
            request.CategoryId,
            request.Description
            );

        var expense = await repository.Create(newExpense, cancellationToken);
        return expense is null
            ? Result.Failure<CreateExpenseResponse>(new Error("400", "Não foi possível cadastrar a despesa.")) 
            : Result.Success(new CreateExpenseResponse(expense.Id, expense.Title.ToString()!, expense.Amount.Value, expense.DueDate.Value, expense.Status, expense.Description.ToString()!, expense.CategoryId));
    }
}