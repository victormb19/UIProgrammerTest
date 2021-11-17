using System;
using UnityEngine;
using UnityMVVM.Binding.Converters;

namespace Ubisoft.UIProgrammerTest.MVMConverters
{
    public class ActivateConverter : ValueConverterBase
    {
        [SerializeField]
        GameObject[] items;

        public override object Convert(object value, Type targetType, object parameter)
        {
            foreach(GameObject gameObject in items)
            {
                if ((string)value == gameObject.name)
                    gameObject.SetActive(true);
                else
                    gameObject.SetActive(false);
            }

            return true;
        }

        public override object ConvertBack(object value, Type targetType, object parameter)
        {
            return null;
        }
    }
}
