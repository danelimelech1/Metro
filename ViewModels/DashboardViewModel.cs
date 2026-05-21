using Metro.Services;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class DashboardViewModel : MvxViewModel
{
    private readonly IDataService _dataService;

    public DashboardViewModel(IDataService dataService)
    {
        _dataService = dataService;
        LoadStats();
    }

    public int TotalUsers { get; private set; }
    public int TotalProducts { get; private set; }
    public int TotalOrders { get; private set; }
    public decimal TotalRevenue { get; private set; }
    public string WelcomeMessage => $"ברוך הבא! היום: {DateTime.Now:dd/MM/yyyy}";

    private void LoadStats()
    {
        TotalUsers = _dataService.GetUsers().Count();
        TotalProducts = _dataService.GetProducts().Count();
        TotalOrders = _dataService.GetOrders().Count();
        TotalRevenue = _dataService.GetOrders().Sum(o => o.TotalAmount);
    }
}
