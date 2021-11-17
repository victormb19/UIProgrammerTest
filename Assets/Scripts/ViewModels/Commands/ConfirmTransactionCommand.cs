
using Ubisoft.UIProgrammerTest.Models.Errors;
using Ubisoft.UIProgrammerTest.Models.Transactions;

namespace Ubisoft.UIProgrammerTest.ViewModels.Commands
{
    public class ConfirmTransactionCommand : Command, ITransactionObserver
    {
        private ConfirmViewModel m_confirmViewModel;
        private LoadingViewModel m_loadingViewModel;
        private ErrorViewModel m_errorViewModel;
        private CurrenciesViewModel m_currenciesViewModel;
        private RewardsViewModel m_rewardsViewModel;

        private Transaction m_transaction;

        public ConfirmTransactionCommand(Transaction transaction)
        {
            m_confirmViewModel = m_viewModelProvider.GetViewModelInstance<ConfirmViewModel>();
            m_loadingViewModel = m_viewModelProvider.GetViewModelInstance<LoadingViewModel>();
            m_errorViewModel = m_viewModelProvider.GetViewModelInstance<ErrorViewModel>();
            m_currenciesViewModel = m_viewModelProvider.GetViewModelInstance<CurrenciesViewModel>();
            m_rewardsViewModel = m_viewModelProvider.GetViewModelInstance<RewardsViewModel>();

            m_transaction = transaction;
            m_transaction.Register(this);
        }

        public override void Execute()
        {
            m_confirmViewModel.Deactive();
            m_loadingViewModel.Active();
            m_transaction.Execute();
        }

        public void ConfirmItem()
        {
            Confirm();

        }

        public void ConfirmReward()
        {
            Confirm();
            m_rewardsViewModel.SetData(m_transaction);
            m_rewardsViewModel.Active();
        }

        private void Confirm()
        {
            m_loadingViewModel.Deactive();
            m_currenciesViewModel.RefreshCurrencies();
        }

        public void Error(ErrorReport errorReport)
        {
            m_loadingViewModel.Deactive();
            m_errorViewModel.errorMessage = errorReport.errorMessage;
            m_errorViewModel.Active();
        }
    }
}
