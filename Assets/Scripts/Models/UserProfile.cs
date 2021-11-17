using System.Collections.Generic;
using Ubisoft.UIProgrammerTest.Models.Currencies;

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

        public bool HasEnoughCurrency(Currency currencyPack)
        {
            Currency currency = GetCurrency(currencyPack.currencyType);
            return currency.IsGreaterOrEquealsThan(currencyPack);
        }

        public void AddCurrency(Currency currencyPack)
        {
            Currency currency = GetCurrency(currencyPack.currencyType);
            currency.AddCurrency(currencyPack);
        }

        public void SubsctractCurrency(Currency currencyPack)
        {
            Currency currency = GetCurrency(currencyPack.currencyType);
            currency.SubstractCurrency(currencyPack);
        }

    }
}
