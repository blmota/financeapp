using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Income.MarkIncomeAsCanceled;

public class MarkIncomeAsCanceledResponse(
    int Id,
    string Title,
    string Description,
    int Amount,
    DateTime Date,
    IncomeStatusEnum IncomeStatus
    );