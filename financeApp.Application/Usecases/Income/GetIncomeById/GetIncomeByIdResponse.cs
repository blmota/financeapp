using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Income.GetIncomeById;

public class GetIncomeByIdResponse(
    int Id,
    string Title,
    string Description,
    int Amount,
    DateTime Date,
    IncomeStatusEnum IncomeStatus
    );