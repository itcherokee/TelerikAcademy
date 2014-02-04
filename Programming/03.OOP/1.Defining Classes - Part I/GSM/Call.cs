namespace Mobile
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Task 8: "Create a class Call to hold a call performed through a GSM. 
    /// It should contain date, time, dialed phone number and duration (in seconds)."
    /// </summary>
    public class Call
    {
        private readonly Guid callID;
        private string dialedPhoneNumber;
        private TimeSpan callDuration;

        public Call(string phoneNum, double callDuration, DateTime? timeOfCall = null)
        {
            do
            {
                this.callID = Guid.NewGuid();
            }
            while (this.CallId == Guid.Empty);
            this.CallPhoneNumber = phoneNum;
            this.CallDuration = callDuration;
            if (timeOfCall.HasValue)
            {
                this.CallDateTime = timeOfCall.Value;
            }
            else
            {
                this.CallDateTime = DateTime.Now - TimeSpan.FromSeconds(this.CallDuration);
            }
        }

        public string CallPhoneNumber
        {
            get
            {
                return this.dialedPhoneNumber;
            }

            set
            {
                if (value != null)
                {
                    // validate phone number against regular expression in order to minimize wrongly typed numbers
                    Match compare = Regex.Match(value, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
                    if (compare.Success)
                    {
                        this.dialedPhoneNumber = value;
                    }
                    else
                    {
                        throw new ArgumentOutOfRangeException("Wrong phone number format provided!");
                    }
                }
                else
                {
                    throw new ArgumentNullException("Null value provided as phone number!");
                }
            }
        }

        public double CallDuration
        {
            get
            {
                return this.callDuration.TotalSeconds;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("It is not posible call duration to be negative value!");
                }

                this.callDuration = TimeSpan.FromSeconds(value);
            }
        }

        public DateTime CallDateTime { get; private set; }

        public Guid CallId
        {
            get { return this.callID; }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine(string.Format("Number dialed: {0}", this.CallPhoneNumber));
            output.AppendLine(string.Format("Dialed on: {0}/{1}/{2}", this.CallDateTime.Day, this.CallDateTime.Month, this.CallDateTime.Year));
            output.AppendLine(string.Format("Dialed at: {0}", this.CallDateTime.TimeOfDay));
            output.Append(string.Format("Call Duration: {0}", this.callDuration));
            return output.ToString();
        }
    }
}