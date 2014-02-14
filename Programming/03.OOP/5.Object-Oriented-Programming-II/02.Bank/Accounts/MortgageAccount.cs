// Mortgage accounts have ½ interest for the first 12 months for companies 
// and no interest for the first 6 months for individuals.

namespace Banking.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class MortgageAccount : Account, IDepositable
    {
        private decimal mortageAmount;

        public MortgageAccount(Customer customer, decimal monthlyInterestRate, decimal mortageAmount)
            : base(customer, monthlyInterestRate)
        {
            this.MortageAmount = mortageAmount;
        }

        public decimal MortageAmount
        {
            get
            {
                return this.mortageAmount;
            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Negative or Zero mortages are not allowed!");
                }

                this.mortageAmount = value;
            }
        }

        public decimal MortageDueAmount
        {
            get
            {
                return this.MortageAmount + this.Interest() - this.Balance;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("Negative or Zero mortage's deposits are not allowed!");
            }

            if (amount > this.MortageDueAmount)
            {
                throw new ArgumentOutOfRangeException("Deposit overcome the mortage amount + interest! Reduce the deposit!");
            }

            this.Balance += amount;
        }

        public override decimal Interest()
        {
            decimal interestAmount = 0.0m;
            int months = this.AccountAgeInMonths;
            if (this.Customer is Company)
            {
                if (months >= 12)
                {
                    // Company has account for more than 12 months: first 12 months are on half interest
                    interestAmount = (12 * (this.MonthlyInterestRate / 2)) + ((months - 12) * this.MonthlyInterestRate);
                }
                else
                {
                    // Company has account for less than 12 months
                    interestAmount = months * (this.MonthlyInterestRate / 2);
                }
            }
            else
            {
                months = months - 6 <= 0 ? 0 : months - 6;
                interestAmount = months * this.MonthlyInterestRate;
            }

            return interestAmount;
        }
    }
}