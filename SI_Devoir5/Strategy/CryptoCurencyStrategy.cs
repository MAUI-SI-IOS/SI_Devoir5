using System;
using System.Collections.Generic;
using System.Text;

namespace SI_Devoir5.Strategy
{
    public class CryptoCurencyStrategy : IPaymentStrategy
    {
        public string Pay(decimal amount) => $"Payment of {amount:C} made using Cryptocurrency.";
    }
}
