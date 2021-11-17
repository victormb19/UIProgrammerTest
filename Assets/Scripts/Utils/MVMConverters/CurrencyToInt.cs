using System;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityEngine;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class CurrencyToInt : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            Currency currency = (Currency)value;
            return currency.amount.ToString();
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
