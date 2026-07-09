using System.Net.Mail;
using financeApp.Domain.Exceptions;

namespace financeApp.Domain.ValueObjects;

public sealed record EmailValueObject
{
    private string Value { get; }

    public EmailValueObject(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new DomainException("E-mail é obrigatório.");

        value = value.Trim().ToLowerInvariant();

        try
        {
            _ = new MailAddress(value);
        }
        catch
        {
            throw new DomainException("E-mail inválido.");
        }

        Value = value;
    }

    public override string ToString() => Value;

    public static implicit operator string(EmailValueObject email) => email.Value;

    public static explicit operator EmailValueObject(string value) => new(value);
}