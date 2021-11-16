using UnityEngine;
using Ubisoft.UIProgrammerTest.Models;
using Ubisoft.UIProgrammerTest.Models.Shops;
using Ubisoft.UIProgrammerTest.ViewModels;
using UnityMVVM.Util;
using Ubisoft.UIProgrammerTest.Models.Shops.Builders;

namespace Ubisoft.UIProgrammerTest
{
    public class UIProgrammer : MonoBehaviour
    {
        private void Awake()
        {
            UserProfile userProfile = new UserProfile();
            Shop shop = new ShopBuilder().Build();

            MainStoreViewModel mainStoreViewModel = ViewModelProvider.Instance.GetViewModelInstance<MainStoreViewModel>();
            mainStoreViewModel.SetData(userProfile, shop);

            MegaPackViewModel megaPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<MegaPackViewModel>();
            megaPackViewModel.SetData(userProfile, shop);

            ConfirmViewModel confirmViewModel = ViewModelProvider.Instance.GetViewModelInstance<ConfirmViewModel>();
            confirmViewModel.Initialize();

            LoadingViewModel loadingViewModel = ViewModelProvider.Instance.GetViewModelInstance<LoadingViewModel>();
            loadingViewModel.Initialize();
        }
    }
}