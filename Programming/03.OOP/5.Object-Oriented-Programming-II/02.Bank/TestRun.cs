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

using System.Collections.Generic;

namespace Banking
{
    using System;
    using Banking.Accounts;
    using Banking.Customers;

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
                Individual clientOne = new Individual("Pencho Pitankata", "Neyde", "1234567890");
                Company clientTwo = new Company("Telerik", "Mladost", "831251108", true);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message + "\n" + ex.StackTrace);
            }

     
            //LoanAccount loan = new LoanAccount(clientOne, 100, 10);
            //loan.AccountStartDate = new DateTime(1999, 1, 1);
            //DepositAccount deposit = new DepositAccount(clientOne, 10099, 10);
            //deposit.AccountStartDate = new DateTime(1999, 1, 1);
            //MortgageAccount mortgage = new MortgageAccount(clientTwo, 100, 10);
            //mortgage.AccountStartDate = new DateTime(2014, 1, 1);
            //Console.WriteLine("Deposit Account Interest: " + deposit.Interest());
            //Console.WriteLine("Loan Account Interest: " + loan.Interest());
            //Console.WriteLine("Mortgage Account Interest: " + mortgage.Interest());
        }
    }
}
