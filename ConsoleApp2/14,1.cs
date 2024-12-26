using BankAccount;

class Program
{
    static void Main(string[] args)
    {
        Account userMainAccount = new Account("Main Account", 100.00m);
        Account userSwissAccount = new Account("Account in Switzerland", 1000000.00m);

        Console.WriteLine("Welcome to your bank application");
        while (true)
        {
            Console.WriteLine("\nChoose an option: ");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Balance");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine();

            Account selectedAccount = null;

            switch (option)
            {
                case "1":
                case "2":
                case "3":
                    Console.Clear();
                    Console.WriteLine("Select account:");
                    Console.WriteLine("1. Main Account");
                    Console.WriteLine("2. Account in Switzerland");

                    string accountChoice = Console.ReadLine();

                    switch (accountChoice)
                    {
                        case "1":
                            selectedAccount = userMainAccount;
                            break;
                        case "2":
                            selectedAccount = userSwissAccount;
                            break;
                        default:
                            Console.WriteLine("Invalid account choice.");
                            continue;
                    }

                    if (option == "3")
                    {
                        Console.Clear();
                        Console.WriteLine($"The balance of {selectedAccount.Name} is: {selectedAccount.Balance}");
                    }
                    else
                    {
                        Console.WriteLine("Enter amount:");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
                        {
                            Console.WriteLine("Invalid amount.");
                            continue;
                        }
                        try
                        {
                            if (option == "1")
                            {
                                Console.Clear();
                                selectedAccount.Deposit(amount);
                                Console.WriteLine($"Deposited {amount} to {selectedAccount.Name}. New balance: {selectedAccount.Balance}");
                            }
                            else if (option == "2")
                            {
                                Console.Clear();
                                selectedAccount.Withdrawal(amount);
                                Console.WriteLine($"Withdrew {amount} from {selectedAccount.Name}. New balance: {selectedAccount.Balance}");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Operation failed: {ex.Message}");
                        }
                    }
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }
}