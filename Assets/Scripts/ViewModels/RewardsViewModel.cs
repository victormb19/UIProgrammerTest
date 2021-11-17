using System.Linq;
using Ubisoft.UIProgrammerTest.Models.Transactions;
using UnityMVVM.ViewModel;

namespace Ubisoft.UIProgrammerTest.ViewModels
{
    public class RewardsViewModel : ViewModelBase
    {
        private string m_tabText = "";
        private string m_titleText = "";
        private string m_prefabName = "";
        private Transaction m_transaction;
        private int index;
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

        public string tabText
        {
            get { return m_tabText; }
            set
            {
                if (value != m_tabText)
                {
                    m_tabText = value;
                    NotifyPropertyChanged(nameof(tabText));
                }
            }
        }

        public string titleText
        {
            get { return m_titleText; }
            set
            {
                if (value != m_titleText)
                {
                    m_titleText = value;
                    NotifyPropertyChanged(nameof(titleText));
                }
            }
        }

        public string prefabName
        {
            get { return m_prefabName; }
            set
            {
                if (value != m_prefabName)
                {
                    m_prefabName = value;
                    NotifyPropertyChanged(nameof(prefabName));
                }
            }
        }

        public void Initialize()
        {
            Deactive();
        }

        public void SetData(Transaction transaction)
        {
            index = 0;
            m_transaction = transaction;
            m_tabText = LocalizationManager.instance.Localize("TID_TAP_TO_CONTINUE");
            Tab();
        }

        public void Active()
        {
            isVisible = true;
        }

        public void Deactive()
        {
            isVisible = false;
        }

        public void Tab()
        {
            if (!IsFinished())
            {
                titleText = m_transaction.transactionPack.packItems[index].itemName;
                prefabName = m_transaction.transactionPack.packItems[index].prefab;
                index++;
            }
            else
            {
                isVisible = false;
            }

        }

        private bool IsFinished()
        {
             return index >= m_transaction.transactionPack.packItems.Count;
        }
    }
}
