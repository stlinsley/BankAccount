using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    public class AccountsSummary
    {
        /*commands available
         * q - exists application
         * l - lists accounts and balances
         * d - deposit
         * w - withdrawal
         * t - transfer
         * s - select account
        */

        public static void AccountsDisplay(AccountHolder accountHolder)
        {
            Console.WriteLine("Accounts");
            Console.WriteLine();
            Console.WriteLine("---------");
            Console.WriteLine();

            accountHolder.ListAccounts();

            Console.WriteLine();

            AccountCommands(accountHolder);
        }

        //TODO: Display currently selected account
        public static void AccountCommands(AccountHolder accountHolder)
        {
            Console.WriteLine("ENTER A COMMAND: [D]EPOSIT [W]ITHDRAW [T]RANSFER [S]ELECT ACCOUNT [L]IST ACCOUNTS [Q]UIT");
            string command = Console.ReadLine().ToUpper();
            switch (command)
            {
                case "D":
                    accountHolder.CurrentlySelectedAccount().DepositFunds();
                    break;
                case "W":
                    accountHolder.CurrentlySelectedAccount().WithdrawFunds();
                    break;
                case "T":
                    accountHolder.CurrentlySelectedAccount().TransferFunds();
                    break;
                case "S":
                    accountHolder.SelectAccount(accountHolder);
                    break;
                case "L":
                    accountHolder.ListAccounts();
                    break;
                case "Q":
                    Quit(accountHolder);
                    break;

                default:
                    Console.WriteLine("Invalid command.");
                    Console.WriteLine();
                    AccountCommands(accountHolder);
                    break;
            }
        }
        public static void Quit(AccountHolder accountHolder)
        {
            Console.WriteLine("Are you sure you want to quit? Y/N");
            string yesno = Console.ReadLine().ToUpper();

            if (yesno == "Y")
            {
                Environment.Exit(0);
            }
            else
            {
                AccountCommands(accountHolder);
            }
        }
    }
}
