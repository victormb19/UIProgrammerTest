using System.Collections.ObjectModel;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using Ubisoft.UIProgrammerTest.Models.Shops;
using Ubisoft.UIProgrammerTest.Models.Transactions;
using Ubisoft.UIProgrammerTest.ViewModels.Commands;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class ConfirmViewModel: ViewModelBase
    {
        private Transaction m_transaction;
        private bool m_isVisible;
        private string m_title;
        private Currency m_currency = new Currency(CurrencyType.Count, 0);

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

        public string title
        {
            get { return m_title; }
            set
            {
                if (value != m_title)
                {
                    m_title = value;
                    NotifyPropertyChanged(nameof(title));
                }
            }
        }


        public Currency currency
        {
            get { return m_currency; }
            set
            {
                if (value != m_currency)
                {
                    m_currency = value;
                    NotifyPropertyChanged(nameof(currency));
                }
            }
        }

        public ObservableCollection<PackItem> MegaPackItems { get; set; } = new ObservableCollection<PackItem>();

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

        public void ShowInfo(Transaction transaction)
        {
            MegaPackItems.Clear();
            m_transaction = transaction;
            title = LocalizationManager.instance.Localize("TID_CONFIRM_MESSAGE");
            currency = m_transaction.transactionPack.currency;
            transaction.transactionPack.packItems.ForEach(item => MegaPackItems.Add(item));
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
