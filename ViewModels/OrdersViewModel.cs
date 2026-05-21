using System.Collections.ObjectModel;
using Metro.Models;
using Metro.Services;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class OrdersViewModel : MvxViewModel
{
    private readonly IDataService _dataService;
    private Order? _selectedOrder;

    public OrdersViewModel(IDataService dataService)
    {
        _dataService = dataService;
        Orders = new ObservableCollection<Order>();
        LoadOrders();
    }

    public ObservableCollection<Order> Orders { get; }

    public Order? SelectedOrder
    {
        get => _selectedOrder;
        set => SetProperty(ref _selectedOrder, value);
    }

    private void LoadOrders()
    {
        Orders.Clear();
        foreach (var o in _dataService.GetOrders())
            Orders.Add(o);
    }
}
