using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Income.MarkIncomeAsReceived;

public class MarkIncomeAsReceivedResponse(
    int Id,
    string Title,
    string Description,
    int Amount,
    DateTime Date,
    IncomeStatusEnum IncomeStatus
    );