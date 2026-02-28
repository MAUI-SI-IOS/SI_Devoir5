using SI_Devoir5.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace SI_Devoir5.State
{
    public class FailureState : IPaymentState
    {
        private FailureState() { }
        private static FailureState instance { get; } = new FailureState();
        public static FailureState Instance() => instance;

        public string GenerateNotificationMessage(Payment payment)
        {
            Debug.Assert(payment != null, "Payment should not be null here");
            Debug.Assert(payment.Amount > 0, "Payment amount should be greater than zero here");
            Debug.Assert(payment.strategy != null, "Payment strategy should not be null here");
            Debug.Assert(payment.strategy is CarteCreditStrategy or PayPalStrategy or CryptoCurencyStrategy);

            var strategyName = payment.strategy switch
            {
                CarteCreditStrategy => "credit card",
                PayPalStrategy => "PayPal",
                CryptoCurencyStrategy => "bank transfer",
            };
            var amount = payment.Amount;
            return $"Your payment of {amount} using {strategyName} has failed. Please try again.";
        }

        public void ProcessPay(Payment payment)
        {
            Debug.Assert(payment != null, "Payment should not be null here");

            Console.WriteLine("Retrying payment");
            // if the payment fails, we can retry the payment by changing the state to ProcessingState?
            payment.state = PendingState.Instance();
            payment.strategy = null; // reset the strategy to null, so the user can choose a new strategy

        }
    }
}
