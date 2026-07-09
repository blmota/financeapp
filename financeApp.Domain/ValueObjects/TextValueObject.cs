using financeApp.Domain.Exceptions;

namespace financeApp.Domain.ValueObjects;

public sealed record TextValueObject
{
    private string? Value { get; }
    
    public TextValueObject(string? value, string title = "Título", int limit = 255, bool isRequired = false)
    {
        Value = value;
        
        if (isRequired && string.IsNullOrWhiteSpace(value))
            throw new DomainException($"{title} obrigatório.");

        if (value != null && value.Length > limit)
            throw new DomainException($"{title} inválido.");

        Value = value;
    }
    
    public override string? ToString() => Value;
}