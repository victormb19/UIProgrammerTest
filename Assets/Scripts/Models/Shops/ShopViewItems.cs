using System;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityMVVM.Model;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class ShopViewItems: ModelBase
    {
        private string m_id;
        private ShopType m_shopType;
        private ShopItemDataType m_shopItemDataType;
        private int m_amount;
        private int m_discount;
        private string m_itemName;
        private string m_itemImage;
        private string m_prefab;

        private Currency m_currency;

        public string id { get => m_id; set => m_id = value; }
        public string prefab { get => m_prefab; set => m_prefab = value; }
        public ShopType shopType { get => m_shopType; set => m_shopType = value; }
        public ShopItemDataType shopItemDataType { get => m_shopItemDataType; set => m_shopItemDataType = value; }
        public int discount { get => m_discount; set => m_discount = value; }
        public string itemName { get => m_itemName; set => m_itemName = value; }
        public string itemImage { get => m_itemImage; set => m_itemImage = value; }
        public Currency currency {get => m_currency; set => m_currency = value; }
        public int amount { get => m_amount; set => m_amount = value; }

    }
}
