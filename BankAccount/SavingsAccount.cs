using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class SavingsAccount : Account
    {
        public SavingsAccount(AccountHolder accountHolder, int accountNumber, decimal balance) : base(accountHolder, accountNumber, balance)
        {
            Type = AccountType.Savings;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountHolder = accountHolder;
        }
    }
}
