using Ubisoft.UIProgrammerTest.Models.Shops;

namespace Ubisoft.UIProgrammerTest.Models.Transactions
{
    public class Transaction : TransactionSubject
    {
        private UserProfile m_userProfile;
        private PackItem m_packItem;

        public Transaction(UserProfile userProfile, PackItem packItem)
        {
            m_userProfile = userProfile;
            m_packItem = packItem;
        }

        public void Execute()
        {

        }

    }
}
