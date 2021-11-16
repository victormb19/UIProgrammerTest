using System;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    class CurrencyToPrice: ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            Currency currency = (Currency)value;
            return string.Concat(currency.amount.ToString("N2"),"€");
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
