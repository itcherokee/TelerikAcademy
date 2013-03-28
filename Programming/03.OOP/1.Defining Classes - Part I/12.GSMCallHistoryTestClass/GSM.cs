namespace MobilePhone
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class GSM
    {
        // fields declarations
        private static readonly GSM iPhone4S =
            new GSM("IPhone 4S", "Apple", 1000, "Nobody", new Battery("Unknown", new TimeSpan(300, 0, 0), new TimeSpan(7, 0, 0), Battery.BatteryType.LiIon), new Display(3.5, 16777216));

        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery gsmBattery;
        private Display gsmDisplay;

        // Static Property for managing the IPhone concrete implementation by the GSM class
        public static GSM IPhone4S
        {
            get
            {
                return iPhone4S;
            }
        }

        // mobile model - there is nothing to check with string values
        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }

        // mobile manufacturer - there is nothing to check with string values
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                this.manufacturer = value;
            }
        }

        // mobile price - value is checked for negative value
        public decimal Price
        {
            get
            {
                return this.price;
            }

            set
            {
                if (value < 0.0M)
                {
                    throw new ArgumentOutOfRangeException("Price can not be negative!");
                }

                this.price = value;
            }
        }

        // owner of the mobile - there is nothing to check with string values
        public string Owner
        {
            get
            {
                return this.owner;
            }

            set
            {
                this.owner = value;
            }
        }

        // static property holding are performed phone calls details. Satic in order to be available and persistent without need for instantiation
        public static List<Call> CallHistory { get; set; }

        // add call to call history
        public void AddPhoneCall(string phoneNum, DateTime callTime, int callDuration)
        {
            CallHistory.Add(new Call(phoneNum, callTime, callDuration));
        }

        // remove call to call history - using Predicate and lambda functions to search for specific (date/time) call within history of calls
        public void RemovePhoneCall(Call call)
        {
            if (CallHistory.Count != 0)
            {
                Predicate<Call> match = x => call.DateAndTime == x.DateAndTime;
                CallHistory.RemoveAt(CallHistory.FindIndex(match));
            }
        }

        // clear all calls from call history
        public void ClearPhoneCalls()
        {
            CallHistory.Clear();
        }

        // calculate total amount in money of all calls in the callhistory
        public decimal SumPhoneCallsPrice(decimal pricePerMinute)
        {
            decimal totalDuration = 0;
            foreach (var call in CallHistory)
            {
                totalDuration += call.Duration;
            }

            return totalDuration / 60 * pricePerMinute;
        }

        // Parameterless constructor calls (chaining) the constructor with full formal parameter list
        static GSM()
        {
            CallHistory = new List<Call>();
        }

        // Parameterless constructor calls (chaining) the constructor with full formal parameter list
        public GSM()
            : this("Generic", "Unknown")
        {
        }

        // Full formal parameter constructor that requires only model & manufacturer fields as mandatory, the rest are optional (default values)
        public GSM(string model, string manufacturer, decimal price = 0.0M, string owner = "", Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.gsmBattery = battery ?? new Battery();
            this.gsmDisplay = display ?? new Display();
        }

        // Overiding ToString method in order to "print" whole information of the GSM class fileds(properties)
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Model: " + this.Model);
            output.Append("\nManufacturer: " + this.Manufacturer);
            output.Append(string.Format("\nPrice: {0:C}\n", this.Price));
            output.Append("Owner: " + this.Owner);
            output.Append("\nBattery Model: " + this.gsmBattery.Model);
            output.Append(string.Format("\nBattery Idle Time: {0:F2}\n", this.gsmBattery.Idle.ToString()));
            output.Append(string.Format("Battery Talk Time: {0:F2}\n", this.gsmBattery.Talk.ToString()));
            output.Append("Battery Type: " + this.gsmBattery.BatType);
            output.Append(string.Format("\nDisplay Size: {0:F} inches\n", this.gsmDisplay.Size));
            output.Append(string.Format("Display Colors: {0:N0}", this.gsmDisplay.Colors));

            // return is calling the base (object) ToString method to print the content of the StringBuilder value output
            return output.ToString();
        }
    }
}