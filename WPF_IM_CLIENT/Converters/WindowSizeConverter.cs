using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WPF_IM_CLIENT.Converters
{
    class WindowSizeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int size = int.Parse(value.ToString());
            return size - 40;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int size = int.Parse(value.ToString());
            return size + 40;
        }

        #endregion
    }
}
