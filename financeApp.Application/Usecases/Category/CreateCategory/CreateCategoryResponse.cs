using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Category.CreateCategory;

public class CreateCategoryResponse(
    int Id,
    string Title, CategoryStatusEnum Status);