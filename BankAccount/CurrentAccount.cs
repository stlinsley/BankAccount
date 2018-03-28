using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    class CurrentAccount : Account
    {

        public CurrentAccount(AccountHolder accountHolder, int accountNumber, decimal balance) : base(accountHolder, accountNumber, balance)
        {
            Type = AccountType.Current;
            AccountNumber = accountNumber;
            Balance = balance;
            AccountHolder = accountHolder;
        }
    }
}