using System;
using System.Collections.Generic;
using System.Text;

namespace SI_Devoir5.Observer
{
    public interface IObserver
    {
        void Notify(string message);
    }
}
