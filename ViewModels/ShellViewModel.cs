using Metro.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class ShellViewModel : MvxViewModel
{
    private readonly IAuthService _authService;
    private int _selectedTabIndex;

    public event Action? LogoutRequested;

    public ShellViewModel(IAuthService authService,
        DashboardViewModel dashboard, UsersViewModel users,
        ProductsViewModel products, OrdersViewModel orders, SettingsViewModel settings)
    {
        _authService = authService;
        Dashboard = dashboard;
        Users = users;
        Products = products;
        Orders = orders;
        Settings = settings;
        LogoutCommand = new MvxCommand(() => LogoutRequested?.Invoke());
    }

    public DashboardViewModel Dashboard { get; }
    public UsersViewModel Users { get; }
    public ProductsViewModel Products { get; }
    public OrdersViewModel Orders { get; }
    public SettingsViewModel Settings { get; }

    public string CurrentUser => _authService.CurrentUser ?? string.Empty;

    public int SelectedTabIndex
    {
        get => _selectedTabIndex;
        set => SetProperty(ref _selectedTabIndex, value);
    }

    public IMvxCommand LogoutCommand { get; }
}
