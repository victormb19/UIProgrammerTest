namespace Ubisoft.UIProgrammerTest.Models.Purchases
{
    public abstract class Purchase
    {
        protected ITransaction m_transaction;

        public Purchase(ITransaction transaction)
        {
            m_transaction = transaction;
        }
        public abstract void Execute();
    }
}
