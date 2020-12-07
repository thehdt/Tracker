using System;
using System.Globalization;
using System.Windows.Data;
using Tracker.Utilities;

namespace Tracker.Converters
{
    public class CodeToCaption : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
                throw new InvalidOperationException("The parameter must be a string");

            return GlobalAppData.RM.GetString((string)parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
