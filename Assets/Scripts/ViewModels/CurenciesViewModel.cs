using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class CurenciesViewModel : ViewModelBase
    {
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


    }
}
