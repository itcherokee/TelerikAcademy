namespace Banking.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class LoanAccount : Account, IDepositable
    {
        private decimal loanAmount;

        public LoanAccount(Customer customer, decimal monthlyInterestRate, decimal loanAmount)
            : base(customer, monthlyInterestRate)
        {
            this.LoanAmount = loanAmount;
        }

        public decimal LoanAmount
        {
            get
            {
                return this.loanAmount;
            }

            private set
            {
                if (value <= 0.0m)
                {
                    throw new ArgumentOutOfRangeException("Negative or Zero loans are not allowed!");
                }

                this.loanAmount = value;
            }
        }

        public decimal LoanDueAmount
        {
            get
            {
                return this.LoanAmount + this.Interest() - this.Balance;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("Negative or Zero loan's deposits are not allowed!");
            }

            if (amount > this.LoanDueAmount)
            {
                throw new ArgumentOutOfRangeException("Deposit overcome the loan amount + interest! Reduce the deposit!");
            }

            this.Balance += amount;
        }

        public override decimal Interest()
        {
            int months = this.AccountAgeInMonths;
            if (this.Customer is Individual)
            {
                months = ((months - 3) <= 0) ? 0 : months - 3;
            }
            else
            {
                months = ((months - 2) <= 0) ? 0 : months - 2;
            }

            return months * this.MonthlyInterestRate;
        }
    }
}