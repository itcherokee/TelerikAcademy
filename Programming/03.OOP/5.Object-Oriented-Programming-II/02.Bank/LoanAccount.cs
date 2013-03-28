// Loan accounts have no interest for the first 3 months if are held by individuals 
// and for the first 2 months if are held by a company.

namespace MyBank
{
    using System;

    public class LoanAccount : Account, IDepositable
    {
        public LoanAccount(Customer customer, decimal initialAmount, decimal interestRate)
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
            int months = Math.Abs((DateTime.Today.Month - StartDate.Month) + (12 * (DateTime.Today.Year - StartDate.Year)));
            if (this.Customer is Individual)
            {
                months = ((months - 3) <= 0) ? 0 : months - 3;
            }
            else
            {
                months = ((months - 2) <= 0) ? 0 : months - 2;
            }

            return (months - 3) * this.InterestRate;
        }
    }
}
