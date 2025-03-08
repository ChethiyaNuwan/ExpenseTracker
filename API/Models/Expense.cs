using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.API.Models;

public class Expense
{
    public int Id { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public decimal Amount { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime Date { get; set; }

    [Required]
    public string Category { get; set; } = string.Empty;
}
