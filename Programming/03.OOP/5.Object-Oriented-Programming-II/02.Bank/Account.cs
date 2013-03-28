namespace MyBank
{
    using System;

    public abstract class Account
    {
        public Customer Customer { get; set; }

        private decimal balance;
        private decimal interestRate;

        public decimal Balance
        {
            get
            {
                return this.balance;
            }

            protected set
            {
                if (value >= 0)
                {
                    this.balance = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative amounts are not allowed!.");
                }
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }

            protected set
            {
                if (value > 0)
                {
                    this.interestRate = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Negative amounts are not allowed!.");
                }
            }
        }

        public DateTime StartDate { get; set; }

        public virtual decimal CalculateInterest()
        {
            int months = Math.Abs((DateTime.Today.Month - this.StartDate.Month) + (12 * (DateTime.Today.Year - this.StartDate.Year)));
            return months * this.InterestRate;
        }
    }
}
