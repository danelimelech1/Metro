# Metro - מערכת ניהול עסקית

אפליקציית ניהול עסקית מבוססת WPF עם עיצוב Dark Mode מלא.

## טכנולוגיות

| טכנולוגיה | גרסה |
|---|---|
| .NET | 10.0 |
| WPF | Windows Presentation Foundation |
| MVVMCross | 9.2.0 |
| MahApps.Metro | 2.4.10 |
| C# | 13 |

## מבנה הפרויקט

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
    ├── LoginView.xaml          # חלון התחברות
    ├── ShellView.xaml          # חלון ראשי עם Tabs
    ├── DashboardView.xaml      # לוח בקרה
    ├── UsersView.xaml          # ניהול משתמשים
    ├── ProductsView.xaml       # ניהול מוצרים
    ├── OrdersView.xaml         # הזמנות
    └── SettingsView.xaml       # הגדרות
```

## פיצ'רים

- **חלון התחברות** — אימות שם משתמש וסיסמא עם הודעות שגיאה ו-loading indicator
- **לוח בקרה** — כרטיסי סטטיסטיקה (משתמשים, מוצרים, הזמנות, הכנסות) וסטטוס מערכת
- **ניהול משתמשים** — DataGrid עם חיפוש, הוספה ומחיקה
- **ניהול מוצרים** — DataGrid עם חיפוש, הוספה ומחיקה
- **הזמנות** — טבלת הזמנות עם סטטוסים צבעוניים
- **הגדרות** — בחירת ערכת צבעים, מצב כהה ושפה
- **Dark Mode** — עיצוב כהה מלא על בסיס MahApps.Metro

## הרצה

```bash
git clone https://github.com/danelimelech1/Metro.git
cd Metro
dotnet run
```

### דרישות מקדימות
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Windows OS (נדרש ל-WPF)

## כניסה למערכת

| משתמש | סיסמא | תפקיד |
|---|---|---|
| `admin` | `admin123` | מנהל |
| `manager` | `manager123` | מנהל מחלקה |
| `user` | `user123` | משתמש |

## ארכיטקטורה

האפליקציה ממשת את דפוס **MVVM** (Model-View-ViewModel):

- **Model** — מחלקות נתונים (`User`, `Product`, `Order`)
- **View** — קבצי XAML עם MahApps.Metro styling
- **ViewModel** — לוגיקת UI עם `MvxViewModel`, commands ו-data binding
- **Services** — שכבת שירותים (`AuthService`, `DataService`) מוזרקת דרך constructor injection
