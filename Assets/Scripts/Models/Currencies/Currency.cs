namespace Ubisoft.UIProgrammerTest.Models.Currencies
{
    public class Currency
    {
        private CurrencyType m_currencyType;
        private float m_amount;

        public Currency(CurrencyType currencyType, float amount)
        {
            m_currencyType = currencyType;
            m_amount = amount;
        }

        public CurrencyType currencyType
        {
            get { return m_currencyType; }
        }

        public float amount
        {
            get { return m_amount; }
        }

        public bool IsGreaterOrEquealsThan(Currency currency)
        {
            return m_amount >= currency.m_amount;
        }

        public void AddCurrency(Currency currency)
        {
            m_amount += currency.m_amount;
        }

        public void SubstractCurrency(Currency currency)
        {
            m_amount -= currency.m_amount;
        }
    }
}