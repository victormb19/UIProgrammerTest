using Ubisoft.UIProgrammerTest.ViewModels.Commands;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class ConfirmViewModel : PopUpViewModel
    {
        private Transaction m_transaction;

        public void SetTransaction(Transaction transaction)
        {
            m_transaction = transaction;
        }
      
        public void ConfirmTransaction()
        {
            ConfirmTransactionCommand confirmTransactionCommand = new ConfirmTransactionCommand(m_transaction);
            confirmTransactionCommand.Execute();
        }

        public void DismissTransaction()
        {
            m_transaction = null;
            Deactive();
        }
    }
}
