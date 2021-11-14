namespace Ubisoft.UIProgrammerTest.ViewModels.Commands
{
    public class ConfirmTransactionCommand : Command
    {
        private ConfirmViewModel m_confirmViewModel;
        private LoadingViewModel m_loadingViewModel;
        private Transaction m_transaction;

        public ConfirmTransactionCommand(Transaction transaction)
        {
            m_confirmViewModel = m_viewModelProvider.GetViewModelInstance<ConfirmViewModel>();
            m_loadingViewModel = m_viewModelProvider.GetViewModelInstance<LoadingViewModel>();
            m_transaction = transaction;
        }

        public override void Execute()
        {
            m_confirmViewModel.Deactive();
            m_loadingViewModel.Active();
          //  m_transaction.Excecute();
        }
    }
}
