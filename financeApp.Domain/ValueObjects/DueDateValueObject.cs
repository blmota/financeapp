using financeApp.Domain.Exceptions;

namespace financeApp.Domain.ValueObjects;

public sealed record DueDateValueObject
{
    public DateOnly Value { get; }

    public DueDateValueObject(DateOnly value)
    {
        if (value == DateOnly.MinValue)
            throw new DomainException("Data de vencimento inválida.");

        Value = value;
    }

    public bool IsOverdue(DateOnly today)
        => Value < today;

    public override string ToString() => Value.ToString("yyyy-MM-dd");

    public static implicit operator DateOnly(DueDateValueObject dueDate) => dueDate.Value;
}