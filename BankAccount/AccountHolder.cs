using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BankAccount
{
    public class AccountHolder
    {
        private string Name;
        private string Address;
        public Dictionary<int, Account> accounts = new Dictionary<int, Account>();
        private Account SelectedAccount;

        public AccountHolder(string name, string address)
        {
            Name = name;
            Address = address;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetAddress()
        {
            return Address;
        }

        public void LinkAccountToHolder(Account account)
        {
            accounts.Add(accounts.Count + 1, account);
            if (accounts.Count == 1)
            {
                SelectedAccount = accounts[1];
            }
            else
            {
                SelectedAccount = CurrentlySelectedAccount();
            }
        }

        public void SelectAccount(AccountHolder accountHolder)
        {
            Console.WriteLine("Available accounts:");
            foreach (var account in accounts)
            {
                Console.WriteLine($"[{account.Key}] {account.Value.GetAccountType()} Account");
            }
            Console.Write($"Please specify which account you want to select? (1, 2, 3 etc.)");
            string selection = Console.ReadLine();
            if (int.TryParse(selection, out int accountSelection))
            {
                if (accounts.ContainsKey(accountSelection))
                {
                    Console.WriteLine($"Account {accountSelection} selected.");
                    SelectedAccount = accounts[accountSelection];
                    Console.WriteLine();
                    AccountsSummary.AccountsDisplay(accountHolder);
                }
                else
                {
                    Console.WriteLine("Invalid selection.");
                    Console.WriteLine();
                    AccountsSummary.AccountsDisplay(accountHolder);
                }
            }
            else
            {
                Console.WriteLine("Invalid selection.");
                AccountsSummary.AccountsDisplay(accountHolder);
            }
        }

        public Account CurrentlySelectedAccount()
        {
            return SelectedAccount;
        }

        public void ListAccounts()
        {
            foreach (var account in accounts)
            {
                if (account.Value.Equals(CurrentlySelectedAccount()))
                {
                    Console.WriteLine($"* [{account.Key}] {account.Value.GetAccountType()} Account        Balance: {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}{account.Value.GetBalance()}");
                }
                else
                {
                    Console.WriteLine($"  [{account.Key}] {account.Value.GetAccountType()} Account        Balance: {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}{account.Value.GetBalance()}");
                }
            }
        }

        public bool GetNonSelectedAccounts()
        {
            foreach (var account in accounts.Where(a => a.Value != CurrentlySelectedAccount()))
            {
                Console.WriteLine($"[{account.Key}] {account.Value.GetAccountType()} Account");
            }
            return true;
        }
    }
}
