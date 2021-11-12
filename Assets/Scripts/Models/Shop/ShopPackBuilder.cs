namespace Ubisoft.UIProgrammerTest.Models.Shop
{
    public class ShopPackBuilder
    {
        ShopPack m_shopPack;

        public ShopPackBuilder()
        {
            m_shopPack = new ShopPack();
        }

        public ShopPack Build()
        {
            return m_shopPack;
        }
    }
}
