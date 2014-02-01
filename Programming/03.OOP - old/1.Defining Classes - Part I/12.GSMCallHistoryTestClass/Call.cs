﻿namespace MobilePhone
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Call
    {
        private string phoneNumber;
        private TimeSpan duration = new TimeSpan();

        public DateTime DateAndTime { get; set; }

        // Property used to R/W and validate phone number
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                // entered phone number is checked against regular expression in order to minimize wrongly typed numbers
                Match compare = Regex.Match(value, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$");
                if (compare.Success)
                {
                    this.phoneNumber = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Wrong number format/content provided!");
                }
            }
        }

        // int property Duration is using a private field duration which is of type TimeSpan,
        // Conversations at vise-versa are done within the property accessors
        public int Duration
        {
            get
            {
                return (int)this.duration.TotalSeconds;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("It is not posible call duration to be negative time!");
                }

                TimeSpan v = new TimeSpan(0, 0, value);
                this.duration = this.duration.Add(v);
            }
        }

        // parameterless class constructor
        public Call()
            : this(string.Empty, DateTime.Now, 0)
        {
        }

        // class constructor initializing all three fields - all manadatory
        public Call(string phoneNum, DateTime callTime, int callDuration)
        {
            this.DateAndTime = callTime;
            this.Duration = callDuration;
            this.PhoneNumber = phoneNum;
        }

        // Overiding ToString method in order to "print" whole information about phone call
        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append("Number dialed: " + this.PhoneNumber);
            output.Append("\nDialed at: " + this.DateAndTime.ToString());
            output.Append("\nCall Duration: " + this.Duration);

            // return is calling the base (object) ToString method to print the content of the StringBuilder value output
            return output.ToString();
        }
    }
}
