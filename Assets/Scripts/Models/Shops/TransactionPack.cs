using System.Collections.Generic;
using Ubisoft.UIProgrammerTest.Models.Currencies;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class TransactionPack
    {
        private string m_id;
        private ShopType m_shopType;
        private Currency m_currency;
        private List<PackItem> m_packItems;

        public TransactionPack(string id, ShopType shopType, Currency currency, List<PackItem> packItems)
        {
            m_id = id;
            m_shopType = shopType;
            m_currency = currency;
            m_packItems = packItems;
        }

        public ShopType shopType { get { return m_shopType; } }
        public Currency currency { get { return m_currency; } }
        public List<PackItem> packItems { get { return m_packItems; } }
    }
}
