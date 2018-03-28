using System;
using System.Collections.Generic;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            AccountHolder RobsAccount = new AccountHolder("Rob", "Robs House, The Lane, Postcode, UK");
            CurrentAccount RobsCurrentAccount = new CurrentAccount(RobsAccount, 12345, 550);
            RobsAccount.LinkAccountToHolder(RobsCurrentAccount);
            SavingsAccount RobsSavingsAccount = new SavingsAccount(RobsAccount, 12346, 2200);
            RobsAccount.LinkAccountToHolder(RobsSavingsAccount);

            Console.WriteLine($"Hello {RobsAccount.GetName()}.");
            Console.WriteLine();
            AccountsSummary.AccountsDisplay(RobsAccount);
        }
    }
}
