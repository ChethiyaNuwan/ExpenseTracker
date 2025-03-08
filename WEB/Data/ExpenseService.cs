using System.Net.Http.Json;

namespace Web.Data;

public class ExpenseService
{
    private readonly HttpClient _http;
    private const string BaseUrl = "http://localhost:5000/api/expenses";

    public ExpenseService(HttpClient http)
    {
        _http = http;
    }

    public async Task<IEnumerable<Expense>> GetExpensesAsync()
    {
        return await _http.GetFromJsonAsync<IEnumerable<Expense>>(BaseUrl) ?? Array.Empty<Expense>();
    }

    public async Task<Expense?> GetExpenseAsync(int id)
    {
        return await _http.GetFromJsonAsync<Expense>($"{BaseUrl}/{id}");
    }

    public async Task<Expense?> CreateExpenseAsync(Expense expense)
    {
        var response = await _http.PostAsJsonAsync(BaseUrl, expense);
        return await response.Content.ReadFromJsonAsync<Expense>();
    }

    public async Task UpdateExpenseAsync(Expense expense)
    {
        await _http.PutAsJsonAsync($"{BaseUrl}/{expense.Id}", expense);
    }

    public async Task DeleteExpenseAsync(int id)
    {
        await _http.DeleteAsync($"{BaseUrl}/{id}");
    }
}
