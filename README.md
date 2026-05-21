# Metro - Business Management System

A WPF business management application with full Dark Mode design.

## Tech Stack

| Technology | Version |
|---|---|
| .NET | 10.0 |
| WPF | Windows Presentation Foundation |
| MVVMCross | 9.2.0 |
| MahApps.Metro | 2.4.10 |
| C# | 13 |

## Project Structure

```
Metro/
├── Core/
│   └── Converters.cs          # XAML value converters
├── Models/
│   ├── User.cs
│   ├── Product.cs
│   └── Order.cs
├── Services/
│   ├── IAuthService.cs / AuthService.cs
│   └── IDataService.cs / DataService.cs
├── ViewModels/
│   ├── LoginViewModel.cs
│   ├── ShellViewModel.cs
│   ├── DashboardViewModel.cs
│   ├── UsersViewModel.cs
│   ├── ProductsViewModel.cs
│   ├── OrdersViewModel.cs
│   └── SettingsViewModel.cs
└── Views/
    ├── LoginView.xaml          # Login window
    ├── ShellView.xaml          # Main window with tabs
    ├── DashboardView.xaml      # Dashboard
    ├── UsersView.xaml          # User management
    ├── ProductsView.xaml       # Product management
    ├── OrdersView.xaml         # Orders
    └── SettingsView.xaml       # Settings
```

## Features

- **Login Window** — Username & password authentication with validation, error messages and loading indicator
- **Dashboard** — Statistics cards (users, products, orders, revenue) and system status panel
- **User Management** — DataGrid with search, add and delete
- **Product Management** — DataGrid with search, add and delete
- **Orders** — Orders table with color-coded status badges
- **Settings** — Theme selector, dark mode toggle and language picker
- **Dark Mode** — Full dark UI built on MahApps.Metro theming

## Getting Started

```bash
git clone https://github.com/danelimelech1/Metro.git
cd Metro
dotnet run
```

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Windows OS (required for WPF)

## Default Credentials

| Username | Password | Role |
|---|---|---|
| `admin` | `admin123` | Administrator |
| `manager` | `manager123` | Department Manager |
| `user` | `user123` | User |

## Architecture

The application follows the **MVVM** pattern:

- **Model** — Data classes (`User`, `Product`, `Order`)
- **View** — XAML files styled with MahApps.Metro
- **ViewModel** — UI logic using `MvxViewModel`, commands and data binding
- **Services** — Service layer (`AuthService`, `DataService`) injected via constructor injection
