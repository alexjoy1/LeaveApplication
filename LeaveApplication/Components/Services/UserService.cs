using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

public class UserService
{
    private readonly HttpClient _httpClient;

    public UserService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<User>> GetUsersAsync()
    {
        try
        {
            var users = await _httpClient.GetFromJsonAsync<List<User>>("https://localhost:7256/api/Users");
            return users ?? new List<User>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching users: {ex.Message}");
            return new List<User>();
        }
    }
    public async Task<User?> CheckLoginAsync(string username, string password)
    {
        var users = await GetUsersAsync();
        return users?.FirstOrDefault(u => u.Username == username && u.Password == password);
    }
}

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
}
