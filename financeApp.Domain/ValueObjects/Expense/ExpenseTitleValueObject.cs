using financeApp.Domain.Exceptions;

namespace financeApp.Domain.ValueObjects.Expense;

public sealed record ExpenseTitleValueObject
{
    public string Value { get; }

    public ExpenseTitleValueObject(string value)
    {
        value = value.Trim();

        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Título obrigatório.");

        if (value.Length > 255)
            throw new DomainException("Título inválido.");

        Value = value;
    }

    public override string ToString() => Value;
}