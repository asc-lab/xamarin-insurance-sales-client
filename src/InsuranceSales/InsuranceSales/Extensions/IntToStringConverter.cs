using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SysConvert = System.Convert;

namespace InsuranceSales.Extensions
{
    public class IntToStringConverter : IValueConverter, IMarkupExtension
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) =>
            SysConvert.ToString(value, culture);

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            string.IsNullOrWhiteSpace((string)value) ? 0 : int.Parse((string)value, culture);

        public object ProvideValue(IServiceProvider serviceProvider) => this;
    }
}
