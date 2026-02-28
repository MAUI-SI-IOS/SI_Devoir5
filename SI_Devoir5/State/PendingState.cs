using SI_Devoir5.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SI_Devoir5.State
{
    internal class PendingState : IPaymentState
    {
        private PendingState() { }
        private static void println(string message) => Console.WriteLine(message);
        private static void print(string message) => Console.Write(message);
        private static PendingState instance { get; } = new PendingState();
        public static PendingState Instance() => instance;
        public void ProcessPay(Payment payment)
        {
            Debug.Assert(payment != null, "Payment cannot be null");

            print("Payment is pending, Should we begin the transaction? (Y/n): ");
            var confirmation = Console.ReadLine();


            if (string.IsNullOrEmpty(confirmation) || string.Equals(confirmation.ToLower(), "y"))
            {
                println("Beginning transaction...");
                IPaymentStrategy? strategy = null;

                while (strategy == null)
                {
                    println("Select a payment method:");
                    println("1. Credit Card");
                    println("2. PayPal");
                    println("3. Crypto Currency");
                    print("Enter the number corresponding to your choice (1-3) : ");
                    var methodInput = Console.ReadLine();

                    strategy = methodInput switch
                    {
                        "1" => new CarteCreditStrategy(),
                        "2" => new PayPalStrategy(),
                        "3" => new CryptoCurencyStrategy(),
                        _ => null
                    };
                }

                payment.SetStrategy(strategy);

                println("Processing payment...");
                var rdm = Random.Shared.Next(0, 2);

                payment.state = (rdm == 0) ? 
                    CompleteState.Instance() : 
                    FailureState.Instance();
            }
            else
            {
                Console.WriteLine("Payment remains pending.");
            }
        }

        public string GenerateNotificationMessage(Payment payment)
        {
            Debug.Assert(payment != null, "Payment cannot be null here");
            Debug.Assert(payment.strategy != null, "Payment strategy should not be null when generating notification message");

            var amount = payment.Amount;
            return payment.strategy.Pay(amount);
        }
    }
}
