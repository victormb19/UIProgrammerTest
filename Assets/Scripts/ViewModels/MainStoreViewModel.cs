using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Ubisoft.UIProgrammerTest.Models;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using Ubisoft.UIProgrammerTest.Models.Shops;
using Ubisoft.UIProgrammerTest.Models.Transactions;
using Ubisoft.UIProgrammerTest.ViewModels.Commands;
using UnityEngine;
using UnityMVVM.Util;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class MainStoreViewModel : ViewModelBase
    {
        private const float RefreshFrequency = 1f;

        private MegaPackViewModel m_megaPackViewModel;
        private SuperPackViewModel m_superPackViewModel;
        private StarterPackViewModel m_starterPackViewModel;

        private UserProfile m_userProfile;
        private Shop m_shop;

        public ObservableCollection<ShopViewItems> GemsItems { get; set; } = new ObservableCollection<ShopViewItems>();
        public ObservableCollection<ShopViewItems> CoinsItems { get; set; } = new ObservableCollection<ShopViewItems>();

        public void SetData(UserProfile userProfile, Shop shop)
        {
            m_userProfile = userProfile;
            m_shop = shop;
            m_megaPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<MegaPackViewModel>();
            m_superPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<SuperPackViewModel>();
            m_starterPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<StarterPackViewModel>();

            StartInvoke();
            UpdatePeriodic();
        }

        public void StopInvoke(Vector2 value)
        {
            CancelInvoke();
        }

        private void StartInvoke()
        {
            InvokeRepeating("UpdatePeriodic", 0f, RefreshFrequency);
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
            HydrateShopPackData(m_shop.activeOfferPacks.ToList());
            m_shop.activePacksGems.ForEach(item => GemsItems.Add(ConvertShopPackToShowViewItem(item)));
            m_shop.activePacksCoins.ForEach(item => CoinsItems.Add(ConvertShopPackToShowViewItem(item)));
        }

        private void HydrateShopPackData(List<ShopPack> ShopPack)
        {
            m_megaPackViewModel.ShopViewPackItem(ConvertShopPackDataPackItem(ShopPack.First()));
            m_superPackViewModel.ShopViewPackItem(ConvertShopPackDataPackItem(ShopPack.Skip(1).First()));
            m_starterPackViewModel.ShopViewPackItem(ConvertShopPackDataPackItem(ShopPack.Last()));
        }

        private Pack ConvertShopPackDataPackItem(ShopPack shopPack)
        {
            List<PackItem> packItems = new List<PackItem>();
            int index = 0;
            shopPack.data.items.ToList().ForEach(item => packItems.Add(ConvertShopItemDataToPackItem(item, index++, shopPack.data.items.Length))); ;
            
            return new Pack()
            {
                id = shopPack.data.id,
                title = LocalizationManager.instance.Localize(shopPack.data.tidName),
                discount = Convert.ToInt32(shopPack.data.discount * 100),
                timeExpire = shopPack.remainingTime,
                price =  new Currency(shopPack.data.currency, shopPack.data.priceBeforeDiscount),
                priceOffer = new Currency(shopPack.data.currency, shopPack.data.price),
                packItems = packItems,
            };
        }

        private PackItem ConvertShopItemDataToPackItem(ShopItemData shopItemData, int index, int totalShopItemData)
        {
            string amountString = (shopItemData.amount > 1) ? shopItemData.amount.ToString() : "";
            return new PackItem()
            {
                shopItemDataType = shopItemData.type,
                prefab = shopItemData.prefab,
                amount = shopItemData.amount,
                itemName = string.Concat(amountString, " ", LocalizationManager.instance.Localize(shopItemData.tidName)),
                itemImage = shopItemData.icon,
                isNotLast = index != totalShopItemData-1
            };
        }

        private ShopViewItems ConvertShopPackToShowViewItem(ShopPack shopPack)
        {
            return new ShopViewItems()
            {
                id = shopPack.data.id,
                amount = shopPack.data.items[0].amount,
                shopType = shopPack.data.type,
                shopItemDataType = shopPack.data.items[0].type,
                currency = new Currency(shopPack.data.currency, shopPack.data.price),
                discount = (int)(shopPack.data.discount * 100),
                itemName = string.Concat(shopPack.data.items[0].amount, " ", LocalizationManager.instance.Localize(shopPack.data.items[0].tidName)),
                itemImage = shopPack.data.items[0].icon,
            };
        }

        public void InitTransaction(ShopViewItems shopViewItems)
        {
            List<PackItem> packItems = new List<PackItem>()
            {
                new PackItem()
                {
                    prefab = shopViewItems.prefab,
                    shopItemDataType = shopViewItems.shopItemDataType,
                    amount = shopViewItems.amount,
                    itemName = shopViewItems.itemName,
                    itemImage = shopViewItems.itemImage,
                }
            };

            TransactionPack transactionPack = new TransactionPack(shopViewItems.id, shopViewItems.shopType, shopViewItems.currency, packItems);
            InitTransationCommand initTransationCommand = new InitTransationCommand(new Transaction(m_userProfile, transactionPack));
            initTransationCommand.Execute();
        }
    }
}
