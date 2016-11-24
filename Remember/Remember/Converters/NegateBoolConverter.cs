using System;
using System.Globalization;
using Xamarin.Forms;

namespace Remember.Converters
{
    public class NegateBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class AddPorcentConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int valueParse = (int)value;
            if (valueParse == 0)
                valueParse = 10;
            int valueParseParameter = 25;
            int.TryParse(parameter as string, out valueParseParameter);

            var returnValue = (((valueParseParameter * valueParse) / 100)) + valueParse;


            return returnValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
