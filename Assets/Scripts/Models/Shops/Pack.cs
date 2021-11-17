using System;
using System.Collections.Generic;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityMVVM.Model;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class Pack: ModelBase
    {
        private string m_id;
        private ShopType m_shopType;
        private string m_title;
        private int m_discount;
        private TimeSpan m_timeExpire;
        private Currency m_price;
        private Currency m_priceOffer;

        private List<PackItem> m_packItems;

        public string id { get => m_id; set => m_id = value; }
        public string title { get => m_title; set => m_title = value; }
        public int discount { get => m_discount; set => m_discount = value; }
        public TimeSpan timeExpire { get => m_timeExpire; set => m_timeExpire = value; }
        public Currency price { get => m_price; set => m_price = value; }
        public Currency priceOffer { get => m_priceOffer; set => m_priceOffer = value; }

        public List<PackItem> packItems { get => m_packItems; set => m_packItems = value; }
    }
}
