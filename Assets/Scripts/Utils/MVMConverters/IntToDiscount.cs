using System;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{

    public class IntToDiscount : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            if ((int)value == 0)
                return "";

            return string.Format("-{0}%",value);
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
