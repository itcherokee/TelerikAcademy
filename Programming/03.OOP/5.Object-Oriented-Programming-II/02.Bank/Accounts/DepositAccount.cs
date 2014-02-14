namespace Banking.Accounts
{
    using System;
    using Customers;
    using Interfaces;

    public class DepositAccount : Account, IWithdrawable, IDepositable
    {
        public DepositAccount(Customer customer, decimal monthlyInterestRate, decimal initialAmount)
            : base(customer, monthlyInterestRate)
        {
            this.Deposit(initialAmount);
        }

        public override decimal Balance
        {
            get
            {
                return base.Balance + this.Interest();
            }

            protected set
            {
                base.Balance = value;
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("Negative or Zero withdraws are not allowed!");
            }

            if (this.Balance - amount < 0.0m)
            {
                throw new ArgumentOutOfRangeException("Not enought money in the account!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0.0m)
            {
                throw new ArgumentOutOfRangeException("Negative or Zero deposits are not allowed!");
            }

            this.Balance += amount;
        }

        public override decimal Interest()
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0.0m;
            }

            return base.Interest();
        }
    }
}
