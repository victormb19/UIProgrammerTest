using System;
using UnityEngine;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class StringToSprite : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            return Resources.Load<Sprite>("UI/ShopItems/Icons/" + value.ToString());
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
