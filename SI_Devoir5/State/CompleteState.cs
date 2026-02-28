using SI_Devoir5.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;

namespace SI_Devoir5.State
{
    public class CompleteState : IPaymentState
    {
        private CompleteState() { }
        private static CompleteState instance = new CompleteState();
        public static CompleteState Instance() => instance;
        public void ProcessPay(Payment payment)
        {
            Debug.Assert(payment != null);

            Console.WriteLine("Payment is already complete. No process needed.");
            // Do nothing, we are already in the complete state
            // @Xavier: I don't know if this is the best way to handle this, but it seems to be the most straightforward way to handle this
            //    you can change it if you find a better way to handle this, but for now, this is how I will handle this
        }

        public string GenerateNotificationMessage(Payment payment)
        {
            Debug.Assert(payment != null, "Payment should not be null here");
            Debug.Assert(payment.strategy != null, "Payment strategy should not be null here");
            Debug.Assert(
                payment.strategy is CarteCreditStrategy or PayPalStrategy or CryptoCurencyStrategy,
                "Payment strategy should be one of the three strategies here"
            );

            var strategyName = payment.strategy switch
            {
                CarteCreditStrategy => "credit card",
                PayPalStrategy => "PayPal",
                CryptoCurencyStrategy => "bank transfer",
            };

            var amount = payment.Amount;
            return $"Your payment of {amount} using {strategyName} has been completed successfully.";
        }
    }
}
