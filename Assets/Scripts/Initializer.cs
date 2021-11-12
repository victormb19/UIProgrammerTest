using Ubisoft.UIProgrammerTest.Models.Shop;

namespace Ubisoft.UIProgrammerTest
{
    public class Initializer
    {
        public Initializer()
        {
            UserProfile userProfile = new UserProfile();
            ShopPackBuilder shopPackBuilder = new ShopPackBuilder();
            ShopPack shopPack = shopPackBuilder.Build();
        }
    }
}
