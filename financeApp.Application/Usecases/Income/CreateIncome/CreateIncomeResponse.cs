using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Income.CreateIncome;

public class CreateIncomeResponse(
    int Id,
    string Title,
    string Description,
    int Amount,
    DateTime Date,
    IncomeStatusEnum IncomeStatus
    );