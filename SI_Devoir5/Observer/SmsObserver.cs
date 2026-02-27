using System;
using System.Collections.Generic;
using System.Text;

namespace SI_Devoir5.Observer
{
    public class SmsObserver : IObserver
    {
        public void Notify(string message) => Console.WriteLine("New SMS was receive.\n" + "...\n" + message);
    }
}
