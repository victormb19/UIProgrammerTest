using Ubisoft.UIProgrammerTest.ViewModels;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityMVVM.Util;
using UnityMVVM.View;

namespace Ubisoft.UIProgrammerTest.Models.Shops
{
    public class CurrencyShopItemList: CollectionViewItemBase<ShopViewItems>
    {
        MainStoreViewModel mainStoreViewModel;

        private void Awake()
        {
            mainStoreViewModel = ViewModelProvider.Instance.GetViewModelInstance<MainStoreViewModel>();
        }

        public override void InitItem(ShopViewItems model, int idx)
        {
            GetComponentInChildren<Button>().onClick.AddListener(new UnityAction(() =>
            {
                mainStoreViewModel.InitTransaction(model);
            }));
        }

        public override void UpdateItem(ShopViewItems model, int newIdx)
        {
        }
    }
}
