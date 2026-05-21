using Metro.Services;
using Metro.ViewModels;
using Metro.Views;
using System.Windows;

namespace Metro;

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        IAuthService authService = new AuthService();
        IDataService dataService = new DataService();

        ShowLogin(authService, dataService);
    }

    private void ShowLogin(IAuthService authService, IDataService dataService)
    {
        var loginVm = new LoginViewModel(authService);
        var loginView = new LoginView { DataContext = loginVm };

        loginVm.LoginSucceeded += () =>
        {
            ShowShell(authService, dataService);
            loginView.Close();
        };

        loginView.Show();
    }

    private void ShowShell(IAuthService authService, IDataService dataService)
    {
        var vm = new ShellViewModel(
            authService,
            new DashboardViewModel(dataService),
            new UsersViewModel(dataService),
            new ProductsViewModel(dataService),
            new OrdersViewModel(dataService),
            new SettingsViewModel(authService)
        );

        var shell = new ShellView { DataContext = vm };

        vm.LogoutRequested += () =>
        {
            authService.Logout();
            shell.Close();
            ShowLogin(authService, dataService);
        };

        MainWindow = shell;
        shell.Show();
    }
}
