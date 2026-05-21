namespace Metro.Services;

public class AuthService : IAuthService
{
    private static readonly Dictionary<string, string> _users = new()
    {
        { "admin", "admin123" },
        { "user", "user123" },
        { "manager", "manager123" }
    };

    public string? CurrentUser { get; private set; }
    public bool IsLoggedIn => CurrentUser != null;

    public bool Login(string username, string password)
    {
        if (_users.TryGetValue(username.ToLower(), out var storedPassword) && storedPassword == password)
        {
            CurrentUser = username;
            return true;
        }
        return false;
    }

    public void Logout()
    {
        CurrentUser = null;
    }
}
