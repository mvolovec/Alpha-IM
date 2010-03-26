using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WPF_IM_CLIENT
{
    public sealed class ImageConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                int iValue = (int)value;
                if (iValue == 0)
                    return new BitmapImage(new Uri("Images/ball_green.png", UriKind.Relative));
                else if (iValue == 1)
                    return new BitmapImage(new Uri("Images/ball_red.png", UriKind.Relative));
                else
                    return new BitmapImage();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
