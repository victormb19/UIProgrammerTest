using SimpleJSON;

namespace Ubisoft.UIProgrammerTest.Models.Shops.Builders
{
   public class ShopItemDataBuilder
   {
        private const string TypeKey = "type";
        private const string ItemIdKey = "itemId";
        private const string AmountKey = "amount";
        private const string TidNameKey = "tidName";
        private const string IconKey = "icon";
        private const string PrefabKey = "prefab";

        private readonly JSONNode m_data;
        private ShopItemData m_shopItemData;

        public ShopItemDataBuilder(JSONNode data)
        {
            m_data = data;
            m_shopItemData = new ShopItemData();
        }

        public ShopItemData Build()
        {
            // Main data
            if (m_data.HasKey(TypeKey))
            {
                Utils.EnumTryParse(m_data[TypeKey], true, out ShopItemDataType shopItemDataType);
                m_shopItemData.type = shopItemDataType;
            }

            // Some other data depends on type
            if (m_shopItemData.isCharacter)
            {
                // Character: force amount to 1
                if (m_data.HasKey(ItemIdKey))
                {
                    m_shopItemData.itemId = m_data[ItemIdKey];
                }

                m_shopItemData.amount = 1;
            }
            else
            {
                // Non-character: force id to ""
                if (m_data.HasKey(AmountKey))
                {
                    m_shopItemData.amount = m_data[AmountKey].AsInt;
                }

                m_shopItemData.itemId = string.Empty;
            }

            // Visuals
            if (m_data.HasKey(TidNameKey))
            {
                m_shopItemData.tidName = m_data[TidNameKey];
            }

            if (m_data.HasKey(IconKey))
            {
                m_shopItemData.icon = m_data[IconKey];
            }

            if (m_data.HasKey(PrefabKey))
            {
                m_shopItemData.prefab = m_data[PrefabKey];
            }

            return m_shopItemData;
        }
    }
}
