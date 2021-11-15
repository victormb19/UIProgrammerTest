using System;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class TimeSpamToString : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            TimeSpan timeSpan = (TimeSpan)value;
            return string.Format("{0}d {1}h {2}m {3}s", timeSpan.Days, timeSpan.Hours,timeSpan.Minutes, timeSpan.Seconds);
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
