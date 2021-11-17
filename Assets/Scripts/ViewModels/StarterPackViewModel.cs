using System;
using System.Collections.ObjectModel;
using Ubisoft.UIProgrammerTest.Models;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using Ubisoft.UIProgrammerTest.Models.Shops;
using Ubisoft.UIProgrammerTest.Models.Transactions;
using Ubisoft.UIProgrammerTest.ViewModels.Commands;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class StarterPackViewModel : ViewModelBase
    {
        private UserProfile m_userProfile;
        private Pack m_pack;

        private string m_title;
        private int m_offerValue;
        private TimeSpan m_timeExpire;

        private Currency m_price;
        private Currency m_priceOffer;

        public ObservableCollection<PackItem> MegaPackItems { get; set; } = new ObservableCollection<PackItem>();

        public string title
        {
            get { return m_title; }
            set
            {
                if (value != m_title)
                {
                    m_title = value;
                    NotifyPropertyChanged(nameof(title));
                }
            }
        }

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

        public Currency price
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

        public Currency priceOffer
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

        public void SetData(UserProfile userProfile)
        {
            m_userProfile = userProfile;
        }

        public void ShopViewPackItem(Pack pack)
        {
            m_pack = pack;
            title = pack.title;
            offerValue = pack.discount;
            timeExpire = pack.timeExpire;
            price = pack.price;
            priceOffer = pack.priceOffer;
            MegaPackItems.Clear();
            pack.packItems.ForEach(item => MegaPackItems.Add(item));
        }

        public void InitTransaction()
        {
            TransactionPack transactionPack = new TransactionPack(m_pack.id, ShopType.Offer, m_pack.priceOffer, m_pack.packItems);
            InitTransationCommand initTransationCommand = new InitTransationCommand(
                new Transaction(m_userProfile, transactionPack));
            initTransationCommand.Execute();
        }
    }
}