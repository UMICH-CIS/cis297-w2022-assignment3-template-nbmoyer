using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Account
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

        public void Credit(decimal credit)
        {
            balance += credit;
        }

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
    }

    class savingsaccount : account
    {
        private decimal interestrate;
        private decimal balance;
        public savingsaccount(decimal intrate, account balance)
        {
            interestrate = intrate;
            balance = balance.balance;
        }
    }

    class checkingaccount : account
    {

    }
}
