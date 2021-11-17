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
        private TransactionPack m_transactionPack;
        private Dictionary<CurrencyType, Purchase> m_purchase;


        public Transaction(UserProfile userProfile, TransactionPack transactionPack)
        {
            m_userProfile = userProfile;
            m_transactionPack = transactionPack;
            m_purchase = new Dictionary<CurrencyType, Purchase>()
                         { 
                             {CurrencyType.Dollars, new DelayPurchase(this) },
                             {CurrencyType.Coins, new InstantPurchase(userProfile, m_transactionPack, this) },
                             {CurrencyType.Gems, new InstantPurchase(userProfile, m_transactionPack, this) }
                          };
        }

        public TransactionPack transactionPack { get => m_transactionPack; }

        public void Execute()
        {
            m_purchase.TryGetValue(m_transactionPack.currency.currencyType, out Purchase purchase);
            purchase.Execute();
        }

        public void FinishTransaction()
        {

            SubstractCurrency();
            AddRewards(m_transactionPack.packItems);

            if (m_transactionPack.shopType == ShopType.Offer)
                ConfirmReward();
            else
                ConfirmItem();
        }

        public void SubstractCurrency()
        {
            if (m_transactionPack.currency.currencyType == CurrencyType.Coins ||
                m_transactionPack.currency.currencyType == CurrencyType.Gems)
                m_userProfile.SubsctractCurrency(m_transactionPack.currency);
        }

        public void AddRewards(List<PackItem> packItems)
        {
            foreach (PackItem packItem in m_transactionPack.packItems)
            {
                switch (packItem.shopItemDataType)
                {
                    case ShopItemDataType.Coins:
                        {
                            Currency currency = new Currency(CurrencyType.Coins, packItem.amount);
                            m_userProfile.AddCurrency(currency);
                        }break;
                    case ShopItemDataType.Gems:
                        {
                            Currency currency = new Currency(CurrencyType.Gems, packItem.amount);
                            m_userProfile.AddCurrency(currency);
                        }
                        break;
                    default:
                        continue;
                }
            }
        }

        public void TransactionError(ErrorReport errorReport)
        {
            Error(errorReport);
        }
    }
}
