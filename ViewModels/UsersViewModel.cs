using System.Collections.ObjectModel;
using Metro.Models;
using Metro.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Metro.ViewModels;

public class UsersViewModel : MvxViewModel
{
    private readonly IDataService _dataService;
    private User? _selectedUser;
    private string _searchText = string.Empty;

    public UsersViewModel(IDataService dataService)
    {
        _dataService = dataService;
        Users = new ObservableCollection<User>();
        LoadUsers();
        DeleteUserCommand = new MvxCommand(DoDeleteUser, () => SelectedUser != null);
        RefreshCommand = new MvxCommand(LoadUsers);
        AddUserCommand = new MvxCommand(DoAddUser);
    }

    public ObservableCollection<User> Users { get; }

    public User? SelectedUser
    {
        get => _selectedUser;
        set
        {
            SetProperty(ref _selectedUser, value);
            DeleteUserCommand.RaiseCanExecuteChanged();
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            SetProperty(ref _searchText, value);
            FilterUsers();
        }
    }

    public IMvxCommand DeleteUserCommand { get; }
    public IMvxCommand RefreshCommand { get; }
    public IMvxCommand AddUserCommand { get; }

    private void LoadUsers()
    {
        Users.Clear();
        foreach (var user in _dataService.GetUsers())
            Users.Add(user);
    }

    private void FilterUsers()
    {
        Users.Clear();
        var all = _dataService.GetUsers();
        var filtered = string.IsNullOrWhiteSpace(SearchText)
            ? all
            : all.Where(u => u.FullName.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                          || u.Username.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                          || u.Email.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        foreach (var user in filtered)
            Users.Add(user);
    }

    private void DoDeleteUser()
    {
        if (SelectedUser == null) return;
        _dataService.DeleteUser(SelectedUser.Id);
        LoadUsers();
        SelectedUser = null;
    }

    private void DoAddUser()
    {
        var newUser = new User
        {
            Username = "new_user",
            FullName = "משתמש חדש",
            Email = "new@metro.com",
            Role = "משתמש",
            IsActive = true
        };
        _dataService.AddUser(newUser);
        LoadUsers();
    }
}
