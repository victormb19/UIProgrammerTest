using System;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class IntToString : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            return value.ToString();
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
