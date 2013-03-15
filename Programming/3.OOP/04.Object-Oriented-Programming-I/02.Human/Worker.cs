namespace MyHuman
{
    using System;
    using System.Linq;
    using System.Text;

    public class Worker : Human
    {
        private int workDays = 5;

        private int workHoursPerDay;

        public decimal WeekSalary { get; private set; }

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

        public Worker(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public Worker(string firstName, string lastName, int workHoursPerDay)
            : this(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
        }

        /// <summary>
        /// Sets Worker weekly salary
        /// </summary>
        /// <param name="salary">Week salary in decimal</param>
        public void SetWeekSalary(decimal salary)
        {
            // separate method for setting salary in order to be more manageble in future developments (control/access rights/etc.)
            try
            {
                if (salary >= 0.0m)
                {
                    // cuts any non zero numbers after second sign after decimal point
                    this.WeekSalary = decimal.Parse(string.Format("{0:F2}", salary));
                }
            }
            catch (Exception)
            {
                // this catches also if there exception in Parsing code above
                throw new ArgumentOutOfRangeException("Invalid value for salary!");
            }
        }

        /// <summary>
        /// Calculates and returns money earned by hour by Worker
        /// </summary>
        /// <returns>Money earned per hour</returns>
        public decimal MoneyPerHour()
        {
            if (this.workDays != 0 && this.WorkHoursPerDay != 0)
            {
                return this.WeekSalary / (this.workDays * this.WorkHoursPerDay);
            }
            else
            {
                return 0.0m;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Name: " + this.FirstName + " " + this.LastName);
            return output.ToString();
        }
    }
}
