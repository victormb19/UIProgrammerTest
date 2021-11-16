using Ubisoft.UIProgrammerTest.Models.Errors;

namespace Ubisoft.UIProgrammerTest.Models.Transactions
{
    public interface ITransactionObserver
    {
        void ConfirmItem();
        void ConfirmReward();
        void Error(ErrorReport errorReport);
    }
}