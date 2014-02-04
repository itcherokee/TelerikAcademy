namespace Mobile
{
    using System;
    using System.Text;

    public class Battery
    {
        private readonly DateTime startUsageOfBattery;
        private readonly BatteryType batteryType;
        private string model;
        private TimeSpan talkTime;

        public Battery()
            : this("Unknown")
        {
        }

        public Battery(string model, BatteryType batteryType = BatteryType.Unknown)
        {
            this.startUsageOfBattery = DateTime.Now;
            this.Model = model;
            this.talkTime = new TimeSpan(0, 0, 0, 0, 0);
            this.batteryType = batteryType;
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Null value is not acceptable value for \"Model\"");
                }

                this.model = value;
            }
        }

        public double IdleHours
        {
            get
            {
                // Time since creation of Battery object minus talk time as single double value.
                return this.CalculateIdleTime().TotalHours;
            }
        }

        public double TalkHours
        {
            get
            {
                return this.talkTime.TotalHours;
            }
        }

        public TimeSpan IdleTime
        {
            get
            {
                // Time since creation of Battery object minus talk time as complex TimeSpan value.
                return this.CalculateIdleTime();
            }
        }

        public TimeSpan TalkTime
        {
            get
            {
                // Time since creation of Battery object minus talk time as complex TimeSpan value.
                return this.talkTime;
            }

            set
            {
                if (value >= TimeSpan.Zero)
                {
                    this.talkTime = this.talkTime.Add(value);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Invalid time has been provided for duration of call!");
                }
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("Model: {0}", this.Model));
            output.AppendLine(string.Format("Type: {0}", this.batteryType));
            output.AppendLine(string.Format("Idle time: {0}", this.IdleTime));
            output.Append(string.Format("Talk time: {0}", this.TalkTime));
            return output.ToString();
        }

        private TimeSpan CalculateIdleTime()
        {
            TimeSpan idleTime = DateTime.Now - this.startUsageOfBattery - this.talkTime;
            return idleTime;
        }
    }
}