// Mortgage accounts have ½ interest for the first 12 months for companies 
// and no interest for the first 6 months for individuals.

namespace MyBank
{
    using System;

    public class MortgageAccount : Account, IDepositable
    {
        public MortgageAccount(Customer customer, decimal initialAmount, decimal interestRate)
        {
            this.Customer = customer;
            this.Deposit(initialAmount);
            this.InterestRate = interestRate;
            this.StartDate = DateTime.Today;
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
            decimal localInterest = 0.0m;
            int months = Math.Abs((DateTime.Today.Month - StartDate.Month) + (12 * (DateTime.Today.Year - StartDate.Year)));
            if (this.Customer is Company)
            {
                localInterest = ((months - 12) <= 0) ? this.InterestRate / 2 : this.InterestRate;
            }
            else
            {
                months = ((months - 6) <= 0) ? 0 : months - 6;
            }

            return (months - 3) * localInterest;
        }
    }
}
