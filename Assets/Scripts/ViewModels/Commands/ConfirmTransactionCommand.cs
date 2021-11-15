
using Ubisoft.UIProgrammerTest.Models.Transactions;

namespace Ubisoft.UIProgrammerTest.ViewModels.Commands
{
    public class ConfirmTransactionCommand : Command, ITransactionObserver
    {
        private ConfirmViewModel m_confirmViewModel;
        private LoadingViewModel m_loadingViewModel;
        private ErrorViewModel m_errorViewModel;
        private Transaction m_transaction;

        public ConfirmTransactionCommand(Transaction transaction)
        {
            m_confirmViewModel = m_viewModelProvider.GetViewModelInstance<ConfirmViewModel>();
            m_loadingViewModel = m_viewModelProvider.GetViewModelInstance<LoadingViewModel>();
            m_errorViewModel = m_viewModelProvider.GetViewModelInstance<ErrorViewModel>();
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
            m_loadingViewModel.Deactive();
        }

        public void ConfirmReward()
        {
            m_loadingViewModel.Deactive();

        }

        public void Error()
        {
            m_errorViewModel.Active();
        }
    }
}
