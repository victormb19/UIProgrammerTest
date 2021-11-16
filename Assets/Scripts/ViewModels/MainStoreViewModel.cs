using System.Collections.ObjectModel;
using Ubisoft.UIProgrammerTest.Models;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using Ubisoft.UIProgrammerTest.Models.Shops;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class MainStoreViewModel : ViewModelBase
    {
        private const float RefreshFrequency = 1f;

        private UserProfile m_userProfile;
        private Shop m_shop;

        public ObservableCollection<PackItem> PackItems { get; set; } = new ObservableCollection<PackItem>();
        public ObservableCollection<ShopViewItems> GemsItems { get; set; } = new ObservableCollection<ShopViewItems>();
        public ObservableCollection<ShopViewItems> CoinsItems { get; set; } = new ObservableCollection<ShopViewItems>();

        public void SetData(UserProfile userProfile, Shop shop)
        {
            m_userProfile = userProfile;
            m_shop = shop;
            InvokeRepeating("UpdatePeriodic", 0f, RefreshFrequency);
            UpdateShopItems();
        }

        private void UpdatePeriodic()
        {
            m_shop.Refresh();
            UpdateShopItems();
        }

        public void UpdateShopItems()
        {
            GemsItems.Clear();
            CoinsItems.Clear();
            m_shop.activePacksOffers.ForEach(item => GemsItems.Add(ConvertShopPachToShowViewItem(item)));
            m_shop.activePacksGems.ForEach(item => GemsItems.Add(ConvertShopPachToShowViewItem(item)));
            m_shop.activePacksCoins.ForEach(item => CoinsItems.Add(ConvertShopPachToShowViewItem(item)));
        }

        public ShopViewItems ConvertShopPachToShowViewItem(ShopPack shopPack)
        {
            return new ShopViewItems()
            {
                currency = new Currency(shopPack.data.currency, shopPack.data.price),
                discount = (int)(shopPack.data.discount * 100),
                itemName = string.Concat(shopPack.data.items[0].amount, " ", LocalizationManager.instance.Localize(shopPack.data.items[0].tidName)),
                itemImage = shopPack.data.items[0].icon,
            };
        }

        public void InitTransaction()
        {
          //  InitTransationCommand initTransationCommand = new InitTransationCommand(new Transaction(userProfile, new PackItem()));
        }



    }
}
