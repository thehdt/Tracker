using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Tracker.Converters
{
    public class TextToVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool && values[1] is bool)
            {
                bool isEmpty = !(bool)values[0];
                bool isFocused = (bool)values[1];

                return (isEmpty || isFocused) ? Visibility.Collapsed : Visibility.Visible;
            }

            return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
