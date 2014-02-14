// Task 2:  A bank holds different types of accounts for its customers: deposit accounts, loan accounts 
//          and mortgage accounts. Customers could be individuals or companies.
//          All accounts have customer, balance and interest rate (monthly based). Deposit accounts are 
//          allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money.
//          All accounts can calculate their interest amount for a given period (in months). In the common
//          case its is calculated as follows: number_of_months * interest_rate.
//          Loan accounts have no interest for the first 3 months if are held by individuals and for 
//          the first 2 months if are held by a company.
//          Deposit accounts have no interest if their balance is positive and less than 1000.
//          Mortgage accounts have ½ interest for the first 12 months for companies and no interest for 
//          the first 6 months for individuals.
//          Your task is to write a program to model the bank system by classes and interfaces. 
//          You should identify the classes, interfaces, base classes and abstract actions and implement
//          the calculation of the interest functionality through overridden methods.

namespace Banking
{
    using System;
    using Accounts;
    using Customers;

    public class TestRun
    {
        public static void Main()
        {
            Bank telerikBank = new Bank("Telerik Bank");
            var e = telerikBank.Accounts;
            foreach (var account in e)
            {
                Console.WriteLine(account);
            }

            try
            {
                Individual clientOne = new Individual("Pencho Pitankata", "Neyde", "1212121230");
                Company clientTwo = new Company("Telerik", "Mladost", "831251119", true);
                DepositAccount depositOne = new DepositAccount(clientOne, 5, 10000);
                DepositAccount depositTwo = new DepositAccount(clientOne, 2, 100, new DateTime(2000, 01, 01));
                DepositAccount depositThree = new DepositAccount(clientOne, 2, 10000, new DateTime(2008, 01, 01));
                LoanAccount loanOne = new LoanAccount(clientOne, 14, 10000, new DateTime(2003, 01, 01));
                LoanAccount loanTwo = new LoanAccount(clientTwo, 14, 10000, new DateTime(2003, 01, 01));
                MortgageAccount mortgageOne = new MortgageAccount(clientOne, 7, 100000, new DateTime(2013, 08, 01));
                MortgageAccount mortgageTwo = new MortgageAccount(clientTwo, 7, 100000, new DateTime(2013, 08, 01));
                Console.WriteLine("Deposit Account 1 Interest: {0:F2}", depositOne.Interest());
                Console.WriteLine("Deposit Account 2 Interest: {0:F2}", depositTwo.Interest());
                Console.WriteLine("Deposit Account 3 Interest: {0:F2}", depositThree.Interest());
                Console.WriteLine("Loan Account Individual Interest: {0:F2}", loanOne.Interest());
                Console.WriteLine("Loan Account Company Interest: {0:F2}", loanTwo.Interest());
                Console.WriteLine("Mortgage Account Interest: {0:F2}", mortgageOne.Interest());
                Console.WriteLine("Mortgage Account Interest: {0:F2}", mortgageTwo.Interest());
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }
        }
    }
}