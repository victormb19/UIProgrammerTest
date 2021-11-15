using Ubisoft.UIProgrammerTest.Models.Transactions;
using Ubisoft.UIProgrammerTest.ViewModels.Commands;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class ConfirmViewModel: ViewModelBase
    {
        private Transaction m_transaction;

        private bool m_isVisible;

        public bool isVisible
        {
            get { return m_isVisible; }
            set
            {
                if (value != m_isVisible)
                {
                    m_isVisible = value;
                    NotifyPropertyChanged(nameof(isVisible));
                }
            }
        }

        public void Initialize()
        {
            Deactive();
        }

        public void Active()
        {
            isVisible = true;
        }

        public void Deactive()
        {
            isVisible = false;
        }

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
