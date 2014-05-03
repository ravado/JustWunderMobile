using JustWunderMobile.Common;
using System;
using System.Windows.Data;

namespace JustWunderMobile.Phone.Classes.Converters
{
    public class MainViewPivotLockConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is MainViewState)
            {
                var converted = (MainViewState)value;
                switch (converted)
                {
                    case MainViewState.NewJokesSelecting: return true;
                    case MainViewState.TopJokesSelecting: return true;
                    case MainViewState.FavoriteJokesSelecting: return true;
                }
            }

            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException("Can`t convert bool to MainViewState");
        }
    }
}
