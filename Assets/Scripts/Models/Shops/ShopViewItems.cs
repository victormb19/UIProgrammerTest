using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityMVVM.Model;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class ShopViewItems: ModelBase
    {
        private int m_discount;
        private string m_itemName;
        private string m_itemImage;

        private Currency m_currency;

        public int discount { get => m_discount; set => m_discount = value; }
        public string itemName { get => m_itemName; set => m_itemName = value; }
        public string itemImage { get => m_itemImage; set => m_itemImage = value; }
        public Currency currency {get => m_currency; set => m_currency = value; }
    }
}
