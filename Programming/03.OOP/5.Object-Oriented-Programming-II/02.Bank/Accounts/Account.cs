using System.Text;

namespace Banking.Accounts
{
    using System;
    using Customers;

    public abstract class Account
    {
        private decimal balance;
        private decimal monthlyInterestRate;

        protected Account(Customer customer, decimal monthlyInterestRate)
        {
            this.AccountStartDate = DateTime.Today;
            this.MonthlyInterestRate = monthlyInterestRate;
            this.Customer = customer;
            this.Balance = 0.0m;
        }

        public Customer Customer { get; private set; }

        public virtual decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value >= 0.0m)
                {
                    this.balance = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative amounts are not allowed!.");
                }
            }
        }

        public decimal MonthlyInterestRate
        {
            get
            {
                return this.monthlyInterestRate;
            }

            protected set
            {
                if (value >= 0.0m)
                {
                    this.monthlyInterestRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative amounts are not allowed!.");
                }
            }
        }

        public DateTime AccountStartDate { get; private set; }

        protected int AccountAgeInMonths
        {
            get
            {
                return Math.Abs((DateTime.Today.Month - this.AccountStartDate.Month) + (12 * (DateTime.Today.Year - this.AccountStartDate.Year)));
            }
        }

        public virtual decimal Interest()
        {
            return this.AccountAgeInMonths * this.MonthlyInterestRate;
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append("Acount:" + this.GetType().Name);
            return output.ToString();
        }
    }
}
