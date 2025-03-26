using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class AuthService
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private const string SessionKey = "auth";

    public AuthService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
    }

    public async Task LoginAsync(string username)
    {
        await _sessionStorage.SetAsync(SessionKey, username);
    }

    public async Task LogoutAsync()
    {
        await _sessionStorage.DeleteAsync(SessionKey);
    }

    public async Task<string> GetUsernameAsync()
    {
        try
        {
            var result = await _sessionStorage.GetAsync<string>(SessionKey);
            return result.Success ? result.Value : null;
        }
        catch (Exception EX)
         
        {
            Console.Write(EX);
            // Handle prerendering scenario
            return null;
        }
    }
}
public class LeaveRequest
{
    public int Id { get; set; }
    public string? EmployeeUsername { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Status { get; set; }
}