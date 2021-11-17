using System;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityMVVM.Model;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class PackItem: ModelBase
    {
        private ShopItemDataType m_shopItemDataType;
        private string m_itemName;
        private string m_itemImage;
        private int m_amount;
        private bool m_isNotLast;
        private string m_prefab;
        private Currency m_currency;

        public ShopItemDataType shopItemDataType { get => m_shopItemDataType; set => m_shopItemDataType = value; }
        public string itemName { get => m_itemName; set => m_itemName = value; }
        public string itemImage { get => m_itemImage; set => m_itemImage = value; }
        public int amount { get => m_amount; set => m_amount = value; }

        public bool isNotLast { get => m_isNotLast; set => m_isNotLast = value; }

        public string prefab { get => m_prefab; set => m_prefab = value; }

        public Currency currency
        {
            get { return m_currency; }
        }
    }
}