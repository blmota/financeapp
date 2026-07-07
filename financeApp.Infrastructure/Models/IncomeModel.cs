using financeApp.Domain.Entities;

namespace financeApp.Infrastructure.Models;

public sealed record IncomeModel
{
    public int Id { get; set; }
    public string Title { get; set; } =  string.Empty;
    public string Description { get; set; } =  string.Empty;
    public int CategoryId { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
}