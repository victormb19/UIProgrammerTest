using Ubisoft.UIProgrammerTest.Models.Errors;
using UnityEngine;

namespace Ubisoft.UIProgrammerTest.Models.Purchases
{
    public class DelayPurchase: Purchase
    {
        private const float IAPFailChance = 0.25f;    // Percentage
        private const float IAPMinDuration = 0.5f;    // Seconds
        private const float IAPMaxDuration = 5f;      // Seconds

        public DelayPurchase(ITransaction transaction) : base(transaction)
        {
        }

        public override void Execute()
        {
            CoroutineManager.DelayedCall(
                                 () =>
                                 {
                                    // Success!
                                    bool success = Random.Range(0f, 1f) > IAPFailChance;    // X% chance of success
                                    if (!success)
                                         m_transaction.TransactionError( new ErrorReportBuilder().Build(ErrorType.StoreFailed));
                                    else
                                        m_transaction.FinishTransaction();
                                 }, Random.Range(IAPMinDuration, IAPMaxDuration)
                             );
        }
    }
}
