using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace Tambayan.Converters
{
    public class TabColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string selectedTab = value?.ToString();
            string targetTab = parameter?.ToString();
            return selectedTab == targetTab ? "#0047FF" : "Transparent";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}