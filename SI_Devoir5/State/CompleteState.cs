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
        public void ChangeState(Payment payment)
        {
            Debug.Assert(payment != null);

            // Do nothing, we are already in the complete state
            // @Xavier: I don't know if this is the best way to handle this, but it seems to be the most straightforward way to handle this
            //    you can change it if you find a better way to handle this, but for now, this is how I will handle this
        }
    }
}
