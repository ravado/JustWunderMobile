using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace JustWunderMobile.Phone.Classes.Converters
{
    public class RelativeTimeConverter : IValueConverter
    {
        private const int MINUTE = 60;
        private const int HOUR = MINUTE * 60;
        private const int DAY = HOUR * 24;
        private const int YEAR = DAY * 365;

        private readonly Dictionary<long, Func<TimeSpan, string>> thresholds = new Dictionary<long, Func<TimeSpan, string>>
        {
            {2, t => "секунду назад"},
            {MINUTE,  t => String.Format("{0} секунд назад", (int)t.TotalSeconds)},
            {MINUTE * 2,  t => "минуту назад"},
            {HOUR,  t => String.Format("{0} минут назад", (int)t.TotalMinutes)},
            {HOUR * 2,  t => "час назад"},
            {DAY,  t => String.Format("{0} часов назад", (int)t.TotalHours)},
            {DAY * 2,  t => "вчера"},
            {DAY * 30,  t => String.Format("{0} дней назад", (int)t.TotalDays)},
            {DAY * 60,  t => "в прошлом месяце"},
            {YEAR,  t => String.Format("{0} месяцев назад", (int)t.TotalDays / 30)},
            {YEAR * 2,  t => "в прошлом году"},
            {Int64.MaxValue,  t => String.Format("{0} лет назад", (int)t.TotalDays / 365)}
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var dateTime = (DateTime)value;
            var difference = DateTime.UtcNow - dateTime.ToUniversalTime();

            return thresholds.First(t => difference.TotalSeconds < t.Key).Value(difference);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
