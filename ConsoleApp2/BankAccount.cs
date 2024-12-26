using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private decimal balance;
        public Account(string name, decimal initialBalance)
        {
            Name = name;
            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative!");
            }
            balance = initialBalance;
        }
        public string Name { get; private set; }
        public decimal Balance
        {
            get { return balance; }
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount cannot be negative!");
            }
            balance += amount;
        }
        public void Withdrawal(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount cannot be negative!");
            }
            if (balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient balance!");
            }
            balance -= amount;
        }
    }
}