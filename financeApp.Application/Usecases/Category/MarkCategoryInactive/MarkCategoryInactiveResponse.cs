using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Category.MarkCategoryInactive;

public class MarkCategoryInactiveResponse(
    int Id,
    string Title,
    CategoryStatusEnum Status
    );