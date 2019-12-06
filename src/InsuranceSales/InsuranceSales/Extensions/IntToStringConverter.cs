using System;
using System.Globalization;
using Xamarin.Forms;
using SysConvert = System.Convert;

namespace InsuranceSales.Extensions
{
    public class IntToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return SysConvert.ToString(value, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.IsNullOrWhiteSpace((string)value) ? 0 : int.Parse((string)value, culture);
        }
    }
}
