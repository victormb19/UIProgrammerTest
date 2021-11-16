namespace Ubisoft.UIProgrammerTest.Models.Shops.Builders
{
    public class ShopPackBuilder
    {
        ShopPack m_shopPack;

        public ShopPackBuilder(ShopPackData _packData)
        {
            m_shopPack = new ShopPack();
            m_shopPack.data = _packData;
        }

        public ShopPack Build()
        {
            return m_shopPack;
        }
	}
}
