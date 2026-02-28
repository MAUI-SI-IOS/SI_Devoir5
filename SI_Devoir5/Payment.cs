using SI_Devoir5.Observer;
using SI_Devoir5.State;
using SI_Devoir5.Strategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SI_Devoir5
{
    public class Payment
    {
        private IPaymentState _state = PendingState.Instance(); 
        public IPaymentState state
        {
            get => _state; 
            set
            {
                Debug.Assert(value != null, "State cannot be null");
                _state = value;
                notifyObservers(_state.GenerateNotificationMessage(this));
            }

        }
        public IPaymentStrategy? strategy;
        public readonly List<IObserver> observers = new List<IObserver>();
        public decimal Amount { get; private set; }

        public Payment(decimal amount)
        {
            Debug.Assert(amount > 0, "Amount should be greater than 0");
            Amount = amount;
        }


        public void SetStrategy(IPaymentStrategy strategy)
        {
            Debug.Assert(strategy != null, "Strategy cannot be null");

            this.strategy = strategy;
        }

        public void Pay()
        {
            Debug.Assert(state != null, "State cannot be null");

            state.ProcessPay(this);
        }

        public void Attach(IObserver observer)
        {
            Debug.Assert(observer != null, "Observer cannot be null");

            observers.Add(observer);
        }

        private void notifyObservers(string message)
        {
            Debug.Assert(observers != null, "Observers cannot be null");

            foreach (var observer in observers)
                observer.Notify(message);
        }
    }
}
