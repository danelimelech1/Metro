using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Metro.Core;

public class StringToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => string.IsNullOrEmpty(value as string) ? Visibility.Collapsed : Visibility.Visible;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class BoolToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? new SolidColorBrush(Color.FromRgb(76, 175, 80)) : new SolidColorBrush(Color.FromRgb(158, 158, 158));

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class BoolToStatusConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        => value is true ? "פעיל" : "לא פעיל";

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

public class StatusToColorConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return (value as string) switch
        {
            "הושלם" => new SolidColorBrush(Color.FromRgb(76, 175, 80)),
            "בטיפול" => new SolidColorBrush(Color.FromRgb(33, 150, 243)),
            "ממתין" => new SolidColorBrush(Color.FromRgb(255, 152, 0)),
            "בוטל" => new SolidColorBrush(Color.FromRgb(244, 67, 54)),
            _ => new SolidColorBrush(Color.FromRgb(158, 158, 158))
        };
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
