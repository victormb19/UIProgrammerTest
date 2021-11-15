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

		public void Error()
		{
			m_observer.Error();
		}
	}
}
