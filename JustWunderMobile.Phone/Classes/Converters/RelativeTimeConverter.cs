using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace JustWunderMobile.Phone.Classes.Converters
{
    public class RelativeTimeConverter : IValueConverter
    {
        private const int Minute = 60;
        private const int Hour = Minute * 60;
        private const int Day = Hour * 24;
        private const int Year = Day * 365;

        private readonly Dictionary<long, Func<TimeSpan, string>> thresholds = new Dictionary<long, Func<TimeSpan, string>>
        {
            {2, t => "секунду назад"},
            {Minute,  t => String.Format("{0} секунд назад", (int)t.TotalSeconds)},
            {Minute * 2,  t => "минуту назад"},
            {Hour,  t => String.Format("{0} минут назад", (int)t.TotalMinutes)},
            {Hour * 2,  t => "час назад"},
            {Day,  t => String.Format("{0} часов назад", (int)t.TotalHours)},
            {Day * 2,  t => "вчера"},
            {Day * 30,  t => String.Format("{0} дней назад", (int)t.TotalDays)},
            {Day * 60,  t => "в прошлом месяце"},
            {Year,  t => String.Format("{0} месяцев назад", (int)t.TotalDays / 30)},
            {Year * 2,  t => "в прошлом году"},
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
