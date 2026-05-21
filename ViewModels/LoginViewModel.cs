using Metro.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class LoginViewModel : MvxViewModel
{
    private readonly IAuthService _authService;
    private string _username = string.Empty;
    private string _password = string.Empty;
    private string _errorMessage = string.Empty;
    private bool _isLoading;

    public event Action? LoginSucceeded;

    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
        LoginCommand = new MvxAsyncCommand(DoLogin);
    }

    public string Username
    {
        get => _username;
        set => SetProperty(ref _username, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public IMvxAsyncCommand LoginCommand { get; }

    private async Task DoLogin()
    {
        ErrorMessage = string.Empty;

        if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
        {
            ErrorMessage = "נא למלא שם משתמש וסיסמא";
            return;
        }

        IsLoading = true;
        await Task.Delay(500);

        if (_authService.Login(Username, Password))
            LoginSucceeded?.Invoke();
        else
            ErrorMessage = "שם משתמש או סיסמא שגויים";

        IsLoading = false;
    }
}
