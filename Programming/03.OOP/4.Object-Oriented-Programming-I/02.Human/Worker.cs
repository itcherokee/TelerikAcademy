namespace People
{
    using System;
    using System.Text;

    public class Worker : Human
    {
        private const int WorkDays = 5;
        private int workHoursPerDay;
        private decimal weekSalary;

        public Worker(string firstName, string lastName, int workHoursPerDay = 0, decimal weeksalary = 0.0m)
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weeksalary;
        }

        /// <summary>
        /// Gets and sets Worker weekly salary.
        /// </summary>
        public decimal WeekSalary
        {
            get
            {
                return this.weekSalary;
            }

            set
            {
                if (value >= 0.0m)
                {
                    this.weekSalary = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid amount for week salary provided. Must be positive!");
                }
            }
        }

        /// <summary>
        /// Gets and sets Worker working hours per day.
        /// </summary>
        public int WorkHoursPerDay
        {
            get
            {
                return this.workHoursPerDay;
            }

            set
            {
                if (value >= 0 && value <= 24)
                {
                    this.workHoursPerDay = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid value for Working Hours per Day!");
                }
            }
        }

        /// <summary>
        /// Calculates and returns money earned by hour by Worker
        /// </summary>
        /// <returns>Money earned per hour</returns>
        public decimal MoneyPerHour()
        {
            if (WorkDays != 0 && this.WorkHoursPerDay != 0)
            {
                return this.WeekSalary / (WorkDays * this.WorkHoursPerDay);
            }

            return 0.0m;
        }
    }
}
