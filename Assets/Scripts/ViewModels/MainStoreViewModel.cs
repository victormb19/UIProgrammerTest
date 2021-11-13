using Ubisoft.UIProgrammerTest.Models.Shops;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class MainStoreViewModel : ViewModelBase
    {
        private UserProfile m_userProfile;
        private Shop m_shop;

        public void SetData(UserProfile userProfile, Shop shop)
        {
            m_userProfile = userProfile;
            m_shop = shop;
        }
    }
}
