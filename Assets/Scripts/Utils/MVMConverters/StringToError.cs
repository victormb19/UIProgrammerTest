using System;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class StringToError : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            return string.Format("<color=#ff0000>{0}</color> ", value.ToString());
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
