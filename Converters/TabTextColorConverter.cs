using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Tambayan.Converters
{
    public class TabTextColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedTab = value?.ToString();
            string targetTab = parameter?.ToString();
            return selectedTab == targetTab ? "White" : "#777";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}