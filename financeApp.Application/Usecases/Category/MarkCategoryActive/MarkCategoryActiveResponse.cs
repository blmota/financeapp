using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Category.MarkCategoryActive;

public class MarkCategoryActiveResponse(
    int Id,
    string Title,
    CategoryStatusEnum Status
    );