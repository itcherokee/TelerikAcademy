namespace MyBank
{
    using System;

    public class DepositAccount : Account, IWithdrawable, IDepositable
    {
        public DepositAccount(Customer customer, decimal initialAmount, decimal interestRate)
        {
            this.Customer = customer;
            this.Deposit(initialAmount);
            this.InterestRate = interestRate;
            this.StartDate = DateTime.Today;
        }

        public void Withdraw(decimal amount)
        {
            decimal delta = this.Balance - amount;
            if (delta < 0)
            {
                throw new ArgumentOutOfRangeException("Not enought money in the account!");
            }

            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Negative or Zero deposits are not allowed!");
            }

            this.Balance += amount;
        }

        public override decimal CalculateInterest()
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0.0m;
            }

            return base.CalculateInterest();
        }
    }
}
