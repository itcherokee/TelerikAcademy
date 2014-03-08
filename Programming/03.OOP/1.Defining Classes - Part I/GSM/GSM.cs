namespace Mobile
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GSM
    {
        private static readonly GSM IPhone =
           new GSM("IPhone 4S", "Apple", 1000, "Nobody", new Battery("Apple", BatteryType.LiPolymer), new Display(3.5, ColorDepth.TrueColor, 640, 960));

        private readonly Battery gsmBattery;
        private readonly Display gsmDisplay;
        private readonly List<Call> callHistory;
        private decimal? price;
        private string model;
        private string manufacturer;

        public GSM()
            : this("Generic", "Unknown")
        {
        }

        public GSM(string model, string manufacturer, decimal? price = null, string owner = null, Battery battery = null, Display display = null)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            if (price.HasValue)
            {
                if (price.Value >= 0.0m)
                {
                    this.price = price;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("It is not allowed to have a negative value for the price!");
                }
            }
            else
            {
                this.price = null;
            }

            this.Owner = owner ?? null;
            this.gsmBattery = battery ?? new Battery();
            this.gsmDisplay = display ?? new Display();
            this.callHistory = new List<Call>();
        }

        public static GSM IPhone4S
        {
            get
            {
                return IPhone;
            }
        }

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Model cannot be null, empty or whitespaces!");
                }

                this.name = value;
            }
        }

        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Manufacturer cannot be null, empty or whitespaces!");
                }

                this.manufacturer = value;
            }
        }

        public string Owner { get; set; }

        public decimal Price
        {
            get
            {
                if (this.price.HasValue)
                {
                    return this.price.Value;
                }

                return 0.0m;
            }
        }

        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory.AsReadOnly();
                //  return new List<Call>(this.callHistory);
            }
        }

        // Add call to call history without specify time/date of call - automaticaly calculated
        public void AddPhoneCall(string dialedNumber, double callDuration)
        {
            this.callHistory.Add(new Call(dialedNumber, callDuration));
            this.gsmBattery.TalkTime = TimeSpan.FromSeconds(callDuration);
        }

        // Add call to call history specifuing time and date of call 
        public void AddPhoneCall(string dialedNumber, double callDuration, DateTime timeOfCall)
        {
            this.callHistory.Add(new Call(dialedNumber, callDuration, timeOfCall));
        }

        // Removes call from call history - using Predicate and lambda functions to search for specific (date/time) call within history of calls
        public void RemovePhoneCall(Guid callId)
        {
            if (this.CallHistory.Count > 0)
            {
                Predicate<Call> match = x => (callId == x.CallId);
                this.callHistory.RemoveAt(this.CallHistory.FindIndex(match));
            }
            else
            {
                throw new ArgumentOutOfRangeException("No such phone call exist in call history!");
            }
        }

        // Clear call history
        public bool ClearPhoneCalls()
        {
            this.callHistory.Clear();
            if (this.CallHistory.Count == 0)
            {
                return true;
            }

            return false;
        }

        // Calculate total amount in money for all calls in the callhistory
        public decimal CalculatePhoneCallsPrice(decimal pricePerMinute)
        {
            double totalDuration = this.CallHistory.Sum(call => call.CallDuration);
            return (decimal)(totalDuration / 60) * pricePerMinute;
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append('=', 20);
            output.AppendLine();
            output.AppendLine("GSM details:");
            output.Append('=', 20);
            output.AppendLine();
            output.AppendLine(string.Format("Model: {0}", this.Model));
            output.AppendLine(string.Format("Manufacturer: {0}", this.Manufacturer));
            output.AppendLine(string.Format("Price: {0:C}", this.Price));
            output.AppendLine(string.Format("Owner: {0}", this.Owner));
            output.AppendLine();
            output.AppendLine("Battery Info");
            output.Append('-', 20);
            output.AppendLine();
            output.AppendLine(this.gsmBattery.ToString());
            output.AppendLine();
            output.AppendLine("Display Info:");
            output.Append('-', 20);
            output.AppendLine();
            output.Append(this.gsmDisplay.ToString());
            return output.ToString();
        }
    }
}