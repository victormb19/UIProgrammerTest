using Ubisoft.UIProgrammerTest.Models.Errors;
using Ubisoft.UIProgrammerTest.Models.Shops;

namespace Ubisoft.UIProgrammerTest.Models.Purchases
{
    public class InstantPurchase : Purchase
    {
        private UserProfile m_userProfile;
        private TransactionPack m_transactionPack;

        public InstantPurchase(UserProfile userProfile,TransactionPack transactionPack, ITransaction transaction) : base (transaction)
        {
            m_userProfile = userProfile;
            m_transactionPack = transactionPack;
        }

        public override void Execute()
        {
            if (!m_userProfile.HasEnoughCurrency(m_transactionPack.currency))
                m_transaction.TransactionError(new ErrorReportBuilder().Build(ErrorType.NotEnoughCurrency));
            else
                m_transaction.FinishTransaction();
        }
    }
}
