using System;
using System.Collections.Generic;
using System.Text;

namespace SI_Devoir5.Strategy
{
    public interface IPaymentStrategy
    {
        string Pay(decimal amount);
    }
}
