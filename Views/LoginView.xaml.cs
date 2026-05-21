using MahApps.Metro.Controls;
using Metro.ViewModels;

namespace Metro.Views;

public partial class LoginView : MetroWindow
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void PasswordBox_PasswordChanged(object sender, System.Windows.RoutedEventArgs e)
    {
        if (DataContext is LoginViewModel vm)
            vm.Password = PasswordBox.Password;
    }
}
