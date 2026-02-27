using System;
using System.Collections.Generic;
using System.Text;

namespace SI_Devoir5.Observer
{
    public class EmailObserver : IObserver
    {
        public void Notify(string message) => Console.WriteLine($"Email Notification: \r\n{message}");
    }
}
