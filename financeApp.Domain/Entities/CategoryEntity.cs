using financeApp.Domain.Abstractions;
using financeApp.Domain.Enums;
using financeApp.Domain.ValueObjects;

namespace financeApp.Domain.Entities;

public class CategoryEntity : Entity
{
    public TextValueObject Title { get; private set; }
    public CategoryStatusEnum Status { get; private set; }

    public CategoryEntity(string title)
    {
        Title = new TextValueObject(value: title, isRequired: true);
        Status = CategoryStatusEnum.Active;
    }

    public void UpdateTitle(string title)
    {
        Title = new TextValueObject(value: title, isRequired: true);
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