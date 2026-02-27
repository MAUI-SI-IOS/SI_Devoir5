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
        public void ChangeState(Payment payment)
        {
            Debug.Assert(payment != null, "Payment should not be null here");

            // if the payment fails, we can retry the payment by changing the state to ProcessingState?
            payment.state = PendingState.Instance();

        }
    }
}
