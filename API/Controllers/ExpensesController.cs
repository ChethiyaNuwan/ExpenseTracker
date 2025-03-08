using Microsoft.AspNetCore.Mvc;
using ExpenseTracker.API.Models;

namespace ExpenseTracker.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExpensesController : ControllerBase
{
    private static List<Expense> _expenses = new();

    [HttpGet]
    public ActionResult<IEnumerable<Expense>> GetExpenses()
    {
        return Ok(_expenses);
    }

    [HttpGet("{id}")]
    public ActionResult<Expense> GetExpense(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense == null)
        {
            return NotFound();
        }
        return Ok(expense);
    }

    [HttpPost]
    public ActionResult<Expense> CreateExpense(Expense expense)
    {
        expense.Id = _expenses.Count + 1;
        _expenses.Add(expense);
        return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateExpense(int id, Expense expense)
    {
        if (id != expense.Id)
        {
            return BadRequest();
        }

        var existingExpense = _expenses.FirstOrDefault(e => e.Id == id);
        if (existingExpense == null)
        {
            return NotFound();
        }

        var index = _expenses.IndexOf(existingExpense);
        _expenses[index] = expense;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteExpense(int id)
    {
        var expense = _expenses.FirstOrDefault(e => e.Id == id);
        if (expense == null)
        {
            return NotFound();
        }

        _expenses.Remove(expense);
        return NoContent();
    }
}
