using System;
using System.Globalization;
using Xamarin.Forms;

namespace Remember.Converters
{
    public class EnableWithOutStringEmptyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var valueParse = value as string;
            if (string.IsNullOrWhiteSpace(valueParse))
                return false;
            else
                return true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}