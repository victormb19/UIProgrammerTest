using Ubisoft.UIProgrammerTest.Models.Shops;
using Ubisoft.UIProgrammerTest.ViewModels;
using UnityMVVM.Util;

namespace Ubisoft.UIProgrammerTest
{
    public class Initializer
    {
        public Initializer()
        {
            UserProfile userProfile = new UserProfile();
			Shop shop = new Shop();

            MainStoreViewModel mainStoreViewModel = ViewModelProvider.Instance.GetViewModelInstance<MainStoreViewModel>();
            mainStoreViewModel.SetData(userProfile, shop);
        }
	}
}
