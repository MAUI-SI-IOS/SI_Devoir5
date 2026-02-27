using System;
using System.Collections.Generic;
using System.Text;

namespace SI_Devoir5.State
{
    public interface IPaymentState
    {
        void ChangeState(Payment payment);
    }
}
