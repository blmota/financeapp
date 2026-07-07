namespace financeApp.Domain.Abstractions;

public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public static readonly Error NullValue = new(
        "General.NullValue",
        "The specified value was null.");
}