using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;

namespace financeApp.Domain.Entities;

public class CategoryEntity : Entity
{
    public string Title { get; private set; }
    public CategoryStatusEnum Status { get; private set; }

    public CategoryEntity(string title)
    {
        Title = title;
        Status = CategoryStatusEnum.Active;
    }

    public void UpdateTitle(string title)
    {
        Title = title;
    }

    public void Active()
    {
        Status = CategoryStatusEnum.Active;
    }

    public void Inactive()
    {
        Status = CategoryStatusEnum.Inactive;
    }
}