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
        public IPaymentState state = PendingState.Instance();
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

            state.ChangeState(this);

            Debug.Assert(strategy != null, "Strategy cannot be null");

            if (state is CompleteState)
            {
                var bill = strategy.Pay(Amount);
                NotifyObservers(bill);
            }
            else if (state is FailureState)
            {
                NotifyObservers("Payment of " + Amount + " failed.");
            }
        }

        public void Attach(IObserver observer)
        {
            Debug.Assert(observer != null, "Observer cannot be null");

            observers.Add(observer);
        }

        private void NotifyObservers(string bill)
        {
            Debug.Assert(observers != null, "Observers cannot be null");

            foreach (var observer in observers)
                observer.Notify(bill);
        }
    }
}
