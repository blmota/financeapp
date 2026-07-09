using financeApp.Domain.Exceptions;

namespace financeApp.Domain.ValueObjects;

public sealed record PasswordValueObject
{
    public string Value { get; }

    public PasswordValueObject(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("Senha é obrigatória.");

        if (value.Length < 8)
            throw new DomainException("A senha deve ter no mínimo 8 caracteres.");

        if (!value.Any(char.IsUpper))
            throw new DomainException("A senha deve conter pelo menos uma letra maiúscula.");

        if (!value.Any(char.IsLower))
            throw new DomainException("A senha deve conter pelo menos uma letra minúscula.");

        if (!value.Any(char.IsDigit))
            throw new DomainException("A senha deve conter pelo menos um número.");

        Value = value;
    }
}