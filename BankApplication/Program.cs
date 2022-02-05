using System;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

  abstract class account
    {
        public abstract void Credit(decimal credit);
        public abstract void Debit(decimal debit);
    }
    class Account : account
    {
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
        public override void Credit(decimal credit)
        {
            balance += credit;
        }

        public override void Debit(decimal debit)
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
    }

    class SavingsAccount : Account
    {
        private decimal interestRate;
        private decimal balance;
        public SavingsAccount(decimal accountBalance, decimal intRate) : base(accountBalance)
        {
            balance = accountBalance;
            interestRate = intRate;
        }
        public decimal CalculateInterest()
        {
            decimal earned;
            earned = interestRate * Balance;
            return earned;
        }
    }

    class CheckingAccount : Account
    {
        private decimal trFee;
        private decimal balance;

        public CheckingAccount(decimal accountBalance, decimal transactionFee) : base(accountBalance)
        {
            balance = accountBalance;
            trFee = transactionFee;
        }

        public override void Credit(decimal credit)
        {
            balance += credit;
            balance -= trFee;
        }

        public override void Debit(decimal debit)
        {
            if (debit <= Balance)
            {
                balance -= debit;
                balance -= trFee;
            }
            else
            {
                Console.WriteLine("Debit amount exceeded account balance.");
            }
        }

    }
}
