using System.Collections.Generic;
using Ubisoft.UIProgrammerTest.Models.Currencies;
using Ubisoft.UIProgrammerTest.Models.Shops;

namespace Ubisoft.UIProgrammerTest.Models
{
    public class UserProfile
    {
        private List<Currency> m_currencies;

        public UserProfile()
        {
            m_currencies = new List<Currency> {
                new Currency(CurrencyType.Gems, 0),
                new Currency(CurrencyType.Coins, 0),
            };
        }

        public Currency GetCurrency(CurrencyType currencyType)
        {
            return m_currencies.Find(currency => currency.currencyType == currencyType);
        } 

        public bool HasEnoughCurrency(PackItem packItem)
        {
            Currency currency = GetCurrency(packItem.currency.currencyType);
            return currency.IsGreaterOrEquealsThan(currency);
        }

        public void ApplyTransaction(PackItem packItem)
        {
            Currency currency = GetCurrency(packItem.currency.currencyType);
            currency.ProcessTransaction(packItem.currency);
        }
    }
}
