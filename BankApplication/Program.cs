using System;

namespace BankApplication
{
    class Program
    {
        /// <summary>
        /// Main function to run banking application
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Which account would you like to manage?");
            Console.WriteLine("1: Savings account");
            Console.WriteLine("2: Checking account");
            Console.WriteLine("3: exit");
            int userInput = int.Parse(Console.ReadLine());
            Program x = new Program();
                switch (userInput)
                {
                    case 1:
                    x.editSavings();
                        break;
                    case 2:
                    x.editChecking();
                        break;
                    case 3:
                        System.Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid input");

                        break;
                }
        }
        /// <summary>
        /// Function to  credit or debit to Savings account
        /// </summary>
        public void editSavings()
        {
            Console.Clear();
            SavingsAccount x = new SavingsAccount((decimal)1000.50, (decimal)0.05);
            Console.WriteLine($"Current savings account balance: {x.MBalance}");
            Console.WriteLine("Enter the action you would like");
            Console.WriteLine("1: Withdraw");
            Console.WriteLine("2: Deposit");
            int userInput = int.Parse(Console.ReadLine());
            

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("How much would you like to withdraw?");
                    decimal withDraw = decimal.Parse(Console.ReadLine());
                    x.Debit(withDraw);
                    Console.WriteLine($"New balance: {x.MBalance}");
                    printInterest(x);
                    break;
                case 2:
                    Console.WriteLine("How much would you like to deposit?");
                    decimal deposit = decimal.Parse(Console.ReadLine());
                    x.Credit(deposit);
                    Console.WriteLine($"New balance: {x.MBalance}");
                    printInterest(x);
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        }
        /// <summary>
        /// Function to print interest earned
        /// </summary>
        /// <param name="x"></param>
        public void printInterest(SavingsAccount x)
        {
            x.Credit(x.CalculateInterest());
            Console.WriteLine($"New balance after calculated interest: {x.MBalance}");
        }
        /// <summary>
        /// Function to credit or debit to checking account. 
        /// </summary>
        public void editChecking()
        {
            Console.Clear();
            CheckingAccount x = new CheckingAccount((decimal)1000.50, (decimal)0.5);
            Console.WriteLine($"Current checking account balance: {x.MBalance}");
            Console.WriteLine("Enter the action you would like");
            Console.WriteLine("1: Withdraw");
            Console.WriteLine("2: Deposit");
            int userInput = int.Parse(Console.ReadLine());


            switch (userInput)
            {
                case 1:
                    Console.WriteLine("How much would you like to withdraw?");
                    decimal withDraw = decimal.Parse(Console.ReadLine());
                    x.CDebit(withDraw);
                    Console.WriteLine($"New balance: {x.MBalance}");
                    break;
                case 2:
                    Console.WriteLine("How much would you like to deposit?");
                    decimal deposit = decimal.Parse(Console.ReadLine());
                    x.CCredit(deposit);
                    Console.WriteLine($"New balance: {x.MBalance}");
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }

        }
    }


    

    /// <summary>
    /// Main parent class for accounts
    /// </summary>
    class Account
    {
        /// <summary>
        /// primary private decimal variable for account balance. 
        /// This is the only variable that is referenced when referring 
        /// to balance and when changes are made to the balance.
        /// </summary>
        private decimal balance;
        public Account(decimal accountBalance)
        {
            if (accountBalance >= 0)
            {
                balance = accountBalance;
            }
            else
            {
                throw new Exception("Initial balance cannot be less than zero");
            }
        }
        /// <summary>
        /// Deposit into account
        /// </summary>
        /// <param name="credit"></param>
        public void Credit(decimal credit)
        {
            balance += credit;
        }
        /// <summary>
        /// withdraw from account
        /// </summary>
        /// <param name="debit"></param>
        public void Debit(decimal debit)
        {
            if (debit <= balance)
            {
                balance -= debit;
            }
            else
            {
                Console.WriteLine("Debit amount exceeded account balance.");
            }
        }

        public decimal Balance
        {
            get { return balance; }
        }
        /// <summary>
        /// Print balance in currency format.
        /// </summary>
        public string MBalance
        {
            get { return string.Format("{0:C}", balance); }
        }
    }

    /// <summary>
    /// Child class of Account for savings account.
    /// </summary>
    class SavingsAccount : Account
    {
        private decimal interestRate;
        private decimal balance;
        public SavingsAccount(decimal accountBalance, decimal intRate) : base(accountBalance)
        {
            balance = accountBalance;
            interestRate = intRate;
        }
        /// <summary>
        /// Funciton to return amount of interest earned from principal balance.
        /// </summary>
        /// <returns></returns>
        public decimal CalculateInterest()
        {
            decimal earned;
            earned = interestRate * Balance;
            return earned;
        }
    }

    /// <summary>
    /// Child class of Account for checking account. 
    /// </summary>
    class CheckingAccount : Account
    {
        /// <summary>
        /// variable for transaction fee
        /// </summary>
        private decimal trFee;
        private decimal balance;

        public CheckingAccount(decimal accountBalance, decimal transactionFee) : base(accountBalance)
        {
            balance = accountBalance;
            trFee = transactionFee;
        }

        /// <summary>
        /// This credit fuction calls the base calss to 
        /// apply the credit and also debit a transaction fee.
        /// </summary>
        /// <param name="credit"></param>
        public void CCredit(decimal credit)
        {
            Credit(credit);
            Debit(trFee);
        }
        /// <summary>
        /// This debit fuction calls the base calss to 
        /// apply the debit and also debit a transaction fee.
        /// Also checks if the debit excedes the balance.
        /// </summary>
        /// <param name="debit"></param>
        public void CDebit(decimal debit)
        {
            if (debit <= Balance)
            {
                Debit(debit);
                Debit(trFee);
            }
            else
            {
                Console.WriteLine("Debit amount exceeded account balance.");
            }
        }

    }
}
