using System.Collections.ObjectModel;
using Metro.Models;
using Metro.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class ProductsViewModel : MvxViewModel
{
    private readonly IDataService _dataService;
    private Product? _selectedProduct;
    private string _searchText = string.Empty;

    public ProductsViewModel(IDataService dataService)
    {
        _dataService = dataService;
        Products = new ObservableCollection<Product>();
        LoadProducts();
        DeleteProductCommand = new MvxCommand(DoDeleteProduct, () => SelectedProduct != null);
        RefreshCommand = new MvxCommand(LoadProducts);
        AddProductCommand = new MvxCommand(DoAddProduct);
    }

    public ObservableCollection<Product> Products { get; }

    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            SetProperty(ref _selectedProduct, value);
            DeleteProductCommand.RaiseCanExecuteChanged();
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            FilterProducts();
        }
    }

    public IMvxCommand DeleteProductCommand { get; }
    public IMvxCommand RefreshCommand { get; }
    public IMvxCommand AddProductCommand { get; }

    private void LoadProducts()
    {
        Products.Clear();
        foreach (var p in _dataService.GetProducts())
            Products.Add(p);
    }

    private void FilterProducts()
    {
        Products.Clear();
        var all = _dataService.GetProducts();
        var filtered = string.IsNullOrWhiteSpace(SearchText)
            ? all
            : all.Where(p => p.Name.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                          || p.Category.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        foreach (var p in filtered)
            Products.Add(p);
    }

    private void DoDeleteProduct()
    {
        if (SelectedProduct == null) return;
        _dataService.DeleteProduct(SelectedProduct.Id);
        LoadProducts();
        SelectedProduct = null;
    }

    private void DoAddProduct()
    {
        var p = new Product
        {
            Name = "מוצר חדש",
            Category = "כללי",
            Price = 0,
            Stock = 0,
            IsActive = true
        };
        _dataService.AddProduct(p);
        LoadProducts();
    }
}
