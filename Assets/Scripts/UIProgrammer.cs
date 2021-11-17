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

            CurrenciesViewModel currenciesViewModel = ViewModelProvider.Instance.GetViewModelInstance<CurrenciesViewModel>();
            currenciesViewModel.SetData(userProfile);

            MainStoreViewModel mainStoreViewModel = ViewModelProvider.Instance.GetViewModelInstance<MainStoreViewModel>();
            mainStoreViewModel.SetData(userProfile, shop);

            MegaPackViewModel megaPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<MegaPackViewModel>();
            megaPackViewModel.SetData(userProfile);

            SuperPackViewModel superPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<SuperPackViewModel>();
            superPackViewModel.SetData(userProfile);

            StarterPackViewModel starterPackViewModel = ViewModelProvider.Instance.GetViewModelInstance<StarterPackViewModel>();
            starterPackViewModel.SetData(userProfile);

            ConfirmViewModel confirmViewModel = ViewModelProvider.Instance.GetViewModelInstance<ConfirmViewModel>();
            confirmViewModel.Initialize();

            LoadingViewModel loadingViewModel = ViewModelProvider.Instance.GetViewModelInstance<LoadingViewModel>();
            loadingViewModel.Initialize();

            ErrorViewModel errorViewModel = ViewModelProvider.Instance.GetViewModelInstance<ErrorViewModel>();
            errorViewModel.Initialize();

            RewardsViewModel rewardsViewModel = ViewModelProvider.Instance.GetViewModelInstance<RewardsViewModel>();
            rewardsViewModel.Initialize();

        }
    }
}