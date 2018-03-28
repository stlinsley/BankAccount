using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BankAccount
{
    public class Account
    {
        protected int AccountNumber;
        protected decimal Balance;
        protected AccountType Type;
        public AccountHolder AccountHolder;

        protected Account(AccountHolder accountHolder, int accountNumber, decimal balance)
        {
            AccountHolder = accountHolder;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public int GetAccountNumber()
        {
            return AccountNumber;
        }

        public decimal GetBalance()
        {
            return Balance;
        }

        public AccountType GetAccountType()
        {
            return Type;
        }

        public bool WithdrawFunds()
        {
            Console.Write($"Please confirm the amount you are taking out: ");
            string takingOut = Console.ReadLine();
            if (decimal.TryParse(takingOut, out decimal amount))
            {
                if (Balance > amount)
                {
                    Balance = Balance - amount;
                    Console.WriteLine($"Withdrawal successful. Account balance is now {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}{Balance}.");
                    Console.WriteLine();
                    AccountsSummary.AccountsDisplay(AccountHolder);
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                    Console.WriteLine();
                    AccountsSummary.AccountsDisplay(AccountHolder);
                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("Invalid input.");
                Console.WriteLine();
                AccountsSummary.AccountsDisplay(AccountHolder);
                return false;
            }
        }

        public bool WithdrawFunds(decimal withdrawalAmount)
        {
                if (Balance > withdrawalAmount)
                {
                    Balance = Balance - withdrawalAmount;
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient funds.");
                    Console.WriteLine();
                    AccountsSummary.AccountsDisplay(AccountHolder);
                    return false;
                }
        }

        //handle negative deposit amounts
        public bool DepositFunds()
        {
            Console.Write($"Please confirm the amount you are paying in: ");
            string payingIn = Console.ReadLine();
            if (decimal.TryParse(payingIn, out decimal amount))
            {
                Balance = Balance + amount;
                Console.WriteLine($"Deposit successful. Account balance is now: {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}{Balance}.");
                Console.WriteLine();
                AccountsSummary.AccountsDisplay(AccountHolder);
                return true;
            }
            else
            {
                Console.WriteLine("Unable to process deposit. Please try again.");
                AccountsSummary.AccountsDisplay(AccountHolder);
                return false;
            }
        }

        public bool DepositFunds(decimal depositAmount)
        {
                Balance = Balance + depositAmount;
                return true;
        }

        public bool TransferFunds()
        {
            Console.WriteLine("Available accounts to transfer to:");
            Console.WriteLine(AccountHolder.GetNonSelectedAccounts());
            Console.Write($"Please specify which account you want to transfer to? (1, 2, 3 etc.) ");
            string transferTo = Console.ReadLine();
            if (int.TryParse(transferTo, out int account))
            {
                Console.Write("How much would you like to transfer: ");
                var transferAmount = Console.ReadLine();
                if (decimal.TryParse(transferAmount, out decimal amount))
                {
                    AccountHolder.accounts.TryGetValue(account, out Account transferToAccount);
                    AccountHolder.CurrentlySelectedAccount().WithdrawFunds(amount);
                    transferToAccount.DepositFunds(amount);
                    Console.WriteLine("Transfer successful.");
                    Console.WriteLine($"{AccountHolder.CurrentlySelectedAccount().GetAccountType()} Account is now {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}{AccountHolder.CurrentlySelectedAccount().Balance}.");
                    Console.WriteLine($"{transferToAccount.GetAccountType()} Account is now {CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol}{transferToAccount.Balance}.");
                    AccountsSummary.AccountsDisplay(AccountHolder);
                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                    AccountsSummary.AccountsDisplay(AccountHolder);
                    return false;
                }
                
            }
            else
            {
                Console.WriteLine("Invalid account.");
                AccountsSummary.AccountsDisplay(AccountHolder);
                return false;
            }
        }

    }
}
