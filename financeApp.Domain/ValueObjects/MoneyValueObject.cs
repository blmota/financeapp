using financeApp.Domain.Exceptions;

namespace financeApp.Domain.ValueObjects;

public sealed record MoneyValueObject
{
    public int Value { get; }

    public MoneyValueObject(int value)
    {
        if (value <= 0)
            throw new DomainException("O valor deve ser maior que zero.");

        Value = value;
    }

    public static MoneyValueObject Zero => new(0);

    public static MoneyValueObject operator +(MoneyValueObject a, MoneyValueObject b)
        => new(a.Value + b.Value);

    public static MoneyValueObject operator -(MoneyValueObject a, MoneyValueObject b)
        => new(a.Value - b.Value);
}