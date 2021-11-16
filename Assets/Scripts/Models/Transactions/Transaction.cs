using System.Collections.Generic;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using Ubisoft.UIProgrammerTest.Models.Errors;
using Ubisoft.UIProgrammerTest.Models.Purchases;
using Ubisoft.UIProgrammerTest.Models.Shops;

namespace Ubisoft.UIProgrammerTest.Models.Transactions
{
    public class Transaction : TransactionSubject, ITransaction
    {
        private UserProfile m_userProfile;
        private PackItem m_packItem;
        private Dictionary<CurrencyType, Purchase> m_purchase;


        public Transaction(UserProfile userProfile, PackItem packItem)
        {
            m_userProfile = userProfile;
            m_packItem = packItem;
            m_purchase = new Dictionary<CurrencyType, Purchase>()
                         { 
                             {CurrencyType.Dollars, new DelayPurchase(this) },
                             {CurrencyType.Coins, new InstantPurchase(userProfile, packItem, this) },
                             {CurrencyType.Gems, new InstantPurchase(userProfile, packItem, this) }
                          };
        }

        public void Execute()
        {
            m_purchase.TryGetValue(m_packItem.currency.currencyType, out Purchase purchase);
            purchase.Execute();
        }

        public void FinishTransaction()
        {
           // m_userProfile.ApplyTransaction(this);
        }

        public void TransactionError(ErrorReport errorReport)
        {
            Error(errorReport);
        }
    }
}
