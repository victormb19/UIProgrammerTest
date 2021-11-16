namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class ShopItemData
    {
        private ShopItemDataType m_type = ShopItemDataType.Coins;
        private int m_amount = 0;   // Characters will have amount 1
        private string m_itemId = "";   // Only for characters, ID of the character
        private string m_tidName = "";  // Text ID of the item
        private string m_icon = "";     // Name of the icon sprite in the Resources folder
        private string m_prefab = "";   // Name of the prefab of the item's 3D view in the Resources folder

        public ShopItemDataType type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public bool isCharacter
        {
            get { return type == ShopItemDataType.Character; }

        }

        public int amount
        {
            get { return m_amount; }
            set { m_amount = value; }
        }

        public string itemId
        {
            get { return m_itemId; }
            set { m_itemId = value; }
        }

        // Visuals
        public string tidName
        {
            get { return m_tidName; }
            set { m_tidName = value; }
        }

        public string icon
        {
            get { return m_icon; }
            set { m_icon = value; }
        }

        public string prefab
        {
            get { return m_prefab; }
            set { m_prefab = value; }
        }
    }
}
