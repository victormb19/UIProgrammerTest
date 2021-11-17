using Ubisoft.UIProgrammerTest.Models.Transactions;

namespace Ubisoft.UIProgrammerTest.ViewModels.Commands
{
    public class InitTransationCommand : Command
    {
        private ConfirmViewModel m_confirmViewModel;
        private Transaction m_transaction;

        public InitTransationCommand(Transaction transaction) : base()
        {
            m_confirmViewModel = m_viewModelProvider.GetViewModelInstance<ConfirmViewModel>();
            m_transaction = transaction;
        } 

        public override void Execute()
        {
            m_confirmViewModel.ShowInfo(m_transaction);
            m_confirmViewModel.Active();
        }
    }
}
