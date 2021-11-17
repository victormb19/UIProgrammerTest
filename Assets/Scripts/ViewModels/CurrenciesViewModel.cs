using System;
using Ubisoft.UIProgrammerTest.Models;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class CurrenciesViewModel : ViewModelBase
    {
        private UserProfile m_userProfile;

        private int m_coins;
        private int m_gems;

        public int coins
        {
            get { return m_coins; }
            set
            {
                if (value != m_coins)
                {
                    m_coins = value;
                    NotifyPropertyChanged(nameof(coins));
                }
            }
        }

        public int gems
        {
            get { return m_gems; }
            set
            {
                if (value != m_gems)
                {
                    m_gems = value;
                    NotifyPropertyChanged(nameof(gems));
                }
            }
        }

        public void SetData(UserProfile userProfile)
        {
            m_userProfile = userProfile;
            RefreshCurrencies();
        }

        public void RefreshCurrencies()
        {
            coins = Convert.ToInt32(m_userProfile.GetCurrency(CurrencyType.Coins).amount);
            gems = Convert.ToInt32(m_userProfile.GetCurrency(CurrencyType.Gems).amount);
        }
    }
}
