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
        private static PendingState instance { get; } = new PendingState();
        public static PendingState Instance() => instance;
        public void ChangeState(Payment payment)
        {
            Debug.Assert(payment != null, "Payment cannot be null");

            println("Payment is pending, Should we begin the transaction? (Y/n): ");
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
                    var methodInput = Console.ReadLine();

                    switch (methodInput)
                    {
                        case "1":
                            strategy = new CarteCreditStrategy();
                            break;
                        case "2":
                            strategy = new PayPalStrategy();
                            break;
                        case "3":
                            strategy = new CryptoCurencyStrategy();
                            break;
                        default:
                            println("Invalid selection, please try again.");
                            break;
                    }
                }

                payment.SetStrategy(strategy);
                println("Processing payment...");
                var rdm = Random.Shared.Next(0, 2);
                if (rdm == 0)
                {
                    println("Payment successful!");
                    payment.state = CompleteState.Instance();
                }
                else
                {
                    println("Payment failed. Please try again.");
                    payment.state = FailureState.Instance();
                }

            }
            else
            {
                Console.WriteLine("Payment remains pending.");
            }
        }
    }
}
