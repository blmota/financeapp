using financeApp.Domain.Enums;

namespace financeApp.Application.Usecases.Category.GetCategoryById;

public class GetCategoryByIdResponse(
    int Id,
    string Title,
    CategoryStatusEnum Status);