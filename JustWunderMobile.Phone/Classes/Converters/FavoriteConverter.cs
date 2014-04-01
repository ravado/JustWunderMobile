using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace JustWunderMobile.Phone.Classes.Converters
{
    public class FavoriteConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                var v = (bool) value;

                if (v)
                {
                    return "/Assets/AppBar/outline_star-32_filled.png";
                    
                }
            }

            return "/Assets/AppBar/outline_star-32.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
