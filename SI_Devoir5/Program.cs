// Simple test harness for the payment simulation
using SI_Devoir5;
using SI_Devoir5.Observer;
using SI_Devoir5.State;

Console.WriteLine("--- Payment Simulation ---");
simulation_start:
decimal amount = 0;
while (true)
{
    Console.Write("Enter an amount to pay: ");
    var input = Console.ReadLine();
    if (!decimal.TryParse(input, out amount) || amount <= 0)
    {
        Console.WriteLine("Please enter a valid positive number.");
        continue;
    }
    break;
}

var payment = new Payment(amount);
// Ask user how they want to be notified and attach observers accordingly
string notifyChoice = "";
while (true)
{
    Console.WriteLine("Choose notification method:");
    Console.WriteLine("1) Email");
    Console.WriteLine("2) SMS");
    Console.WriteLine("3) Both (Email + SMS)");
    Console.Write("Selection (1-4): ");
    notifyChoice = Console.ReadLine() ?? "";
    if (notifyChoice == "1" || notifyChoice == "2" || notifyChoice == "3" || notifyChoice == "4")
        break;
    Console.WriteLine("Invalid selection, please choose 1-4.");
}

switch (notifyChoice)
{
    case "1":
        payment.Attach(new EmailObserver());
        break;
    case "2":
        payment.Attach(new SmsObserver());
        break;
    case "3":
        payment.Attach(new EmailObserver());
        payment.Attach(new SmsObserver());
        break;
}

// Loop until payment reaches the completed state
payment.Pay();
// If failure, allow retry loop will continue because FailureState.ChangeState may set PendingState
if (payment.state is not CompleteState)
{
    Console.WriteLine("Transaction failed...\nRetrying...");
    goto simulation_start;
}

Console.WriteLine("Transaction completed successfully!");



Console.WriteLine("Payment flow ended. Press any key to exit.");
Console.ReadKey();
