using Ubisoft.UIProgrammerTest.Models.Errors;

namespace Ubisoft.UIProgrammerTest.Models
{
    public interface ITransaction
    {
        void FinishTransaction();
        void TransactionError(ErrorReport errorReport);
    }
}
