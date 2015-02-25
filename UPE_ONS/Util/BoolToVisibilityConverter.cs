using System;
using System.Windows;
using System.Windows.Data;

namespace UPE_ONS.Util
{
    public class BoolToVisibilityConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                bool b = (bool)value;
                if (b) return Visibility.Visible;
            }
            catch { }


            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
