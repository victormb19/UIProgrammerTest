namespace Ubisoft.UIProgrammerTest.Models.Transactions
{
    public interface ITransactionObserver
    {
        void ConfirmItem();
        void ConfirmReward();
        void Error();
    }
}