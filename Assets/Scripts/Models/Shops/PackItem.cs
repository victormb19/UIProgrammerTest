using UnityMVVM.Model;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class PackItem: ModelBase
    {
        private string m_itemName;
        private string m_itemImage;

        public string itemName { get => m_itemName; set => m_itemName = value; }
        public string itemImage { get => m_itemImage; set => m_itemImage = value; }
    }
}