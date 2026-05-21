namespace Metro.Services;

public interface IAuthService
{
    bool Login(string username, string password);
    void Logout();
    string? CurrentUser { get; }
    bool IsLoggedIn { get; }
}
