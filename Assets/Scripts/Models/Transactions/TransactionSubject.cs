using Ubisoft.UIProgrammerTest.Models.Errors;

namespace Ubisoft.UIProgrammerTest.Models.Transactions
{
    public class TransactionSubject
    {
		private ITransactionObserver m_observer;

		public void Register(ITransactionObserver observer)
		{
			m_observer = observer;
		}

		public void ConfirmItem()
        {
			m_observer.ConfirmItem();
        }

		public void ConfirmReward()
        {
			m_observer.ConfirmReward();
        }

		public void Error(ErrorReport errorReport)
		{
			m_observer.Error(errorReport);
		}
	}
}
