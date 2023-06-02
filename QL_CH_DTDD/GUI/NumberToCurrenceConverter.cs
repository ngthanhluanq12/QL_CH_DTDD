using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace QL_CH_DTDD.GUI
{
    public class NumberToCurrenceConverter : IValueConverter
    {
        public NumberToCurrenceConverter()
        {
        }
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = (int)value;
            var info = CultureInfo.GetCultureInfo("vi-VN");
            string currencyString = string.Format(info, "{0:c}", number);
            return currencyString;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
