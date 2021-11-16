using Ubisoft.UIProgrammerTest.Models.Errors;
using Ubisoft.UIProgrammerTest.Models.Shops;

namespace Ubisoft.UIProgrammerTest.Models.Purchases
{
    public class InstantPurchase : Purchase
    {
        private UserProfile m_userProfile;
        private PackItem m_packItem;

        public InstantPurchase(UserProfile userProfile, PackItem packItem, ITransaction transaction) : base (transaction)
        {
            m_userProfile = userProfile;
            m_packItem = packItem;
        }

        public override void Execute()
        {
            if (m_userProfile.HasEnoughCurrency(m_packItem))
                m_transaction.TransactionError(new ErrorReportBuilder().Build(ErrorType.NotEnoughCurrency));
            else
                m_transaction.FinishTransaction();
        }
    }
}
