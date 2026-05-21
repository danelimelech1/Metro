using Metro.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class SettingsViewModel : MvxViewModel
{
    private readonly IAuthService _authService;
    private string _selectedTheme = "Blue";
    private bool _isDarkMode;
    private string _language = "עברית";

    public SettingsViewModel(IAuthService authService)
    {
        _authService = authService;
        SaveCommand = new MvxCommand(DoSave);
    }

    public string SelectedTheme
    {
        get => _selectedTheme;
        set => SetProperty(ref _selectedTheme, value);
    }

    public bool IsDarkMode
    {
        get => _isDarkMode;
        set => SetProperty(ref _isDarkMode, value);
    }

    public string Language
    {
        get => _language;
        set => SetProperty(ref _language, value);
    }

    public string CurrentUser => _authService.CurrentUser ?? string.Empty;

    public string[] AvailableThemes => new[] { "Blue", "Red", "Green", "Purple", "Orange", "Teal" };

    public IMvxCommand SaveCommand { get; }

    private void DoSave()
    {
        // Save settings logic here
    }
}
