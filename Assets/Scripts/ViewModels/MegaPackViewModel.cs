using System;
using System.Collections.ObjectModel;
using Ubisoft.UIProgrammerTest.Models;
using Ubisoft.UIProgrammerTest.Models.Shops;
using Ubisoft.UIProgrammerTest.Models.Transactions;
using Ubisoft.UIProgrammerTest.ViewModels.Commands;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class MegaPackViewModel: ViewModelBase
    {

        private UserProfile m_userProfile;
        private Shop m_shop;

        private int m_offerValue;
        private TimeSpan m_timeExpire;

        private int m_price;
        private int m_priceOffer;

        public ObservableCollection<PackItem> MegaPackItems { get; set; } = new ObservableCollection<PackItem>();

        public int offerValue
        {
            get { return m_offerValue; }
            set
            {
                if (value != m_offerValue)
                {
                    m_offerValue = value;
                    NotifyPropertyChanged(nameof(offerValue));
                }
            }
        }

        public TimeSpan timeExpire
        {
            get { return m_timeExpire; }
            set
            {
                if (value != m_timeExpire)
                {
                    m_timeExpire = value;
                    NotifyPropertyChanged(nameof(timeExpire));
                }
            }
        }

        public int price
        {
            get { return m_price; }
            set
            {
                if (value != m_price)
                {
                    m_price = value;
                    NotifyPropertyChanged(nameof(price));
                }
            }
        }

        public int priceOffer
        {
            get { return m_priceOffer; }
            set
            {
                if (value != m_priceOffer)
                {
                    m_priceOffer = value;
                    NotifyPropertyChanged(nameof(priceOffer));
                }
            }
        }

        public void SetData(UserProfile userProfile, Shop shop)
        {
            m_userProfile = userProfile;
            m_shop = shop;
            Initialize();
        }

        private void Initialize()
        {
            offerValue = 80;
            timeExpire = new TimeSpan(5, 10, 2, 10);
            price = 2999;
            priceOffer = 599;
            MegaPackItems.Add(new PackItem() { itemImage = "icon_character_2", itemName = "Hodur" });
            MegaPackItems.Add(new PackItem() { itemImage = "icon_pack_gems_1", itemName = "400 Gems" });
            MegaPackItems.Add(new PackItem() { itemImage = "icon_pack_coins_2", itemName = "3500 Coins" });
        }

        public void InitTransaction()
        {
             InitTransationCommand initTransationCommand = new InitTransationCommand(
                 new Transaction(m_userProfile, new PackItem()));
            initTransationCommand.Execute();
        }
    }
}
