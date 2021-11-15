using System;
using UnityEditor;
using UnityEngine;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class StringToSprite : ValueConverterBase
    {
        public override object Convert(object value, Type targetType, object parameter)
        {
            return AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Art/UI/ShopItems/Icons/" + value.ToString() + ".png");
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
