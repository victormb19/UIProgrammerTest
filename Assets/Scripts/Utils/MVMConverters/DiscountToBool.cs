using System;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    class DiscountToBool : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            return (int)value > 0;
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
