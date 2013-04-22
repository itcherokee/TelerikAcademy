namespace CSharpEvents
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        private readonly DateTime eventDate;
        private readonly string eventTitle;
        private readonly string eventLocation;

        internal Event(DateTime eventDate, string eventTitle, string eventLocation)
        {
            this.eventDate = eventDate;
            this.eventTitle = eventTitle;
            this.eventLocation = eventLocation;
        }

        public int CompareTo(object eventToCompareTo)
        {
            if (eventToCompareTo == null)
            {
                return 1;
            }

            Event comparedEvent = eventToCompareTo as Event;
            if (comparedEvent == null)
            {
                throw new ArgumentException("Object to compare to is not of Event type.");
            }

            int compareByDate = this.eventDate.CompareTo(comparedEvent.eventDate);
            int compareByTitle = this.eventTitle.CompareTo(comparedEvent.eventTitle);
            int compareByLocation = this.eventLocation.CompareTo(comparedEvent.eventLocation);
            if (compareByDate == 0)
            {
                if (compareByTitle == 0)
                {
                    return compareByLocation;
                }
                else
                {
                    return compareByTitle;
                }
            }
            else
            {
                return compareByDate;
            }
        }

        public override string ToString()
        {
            StringBuilder eventOutput = new StringBuilder();
            eventOutput.Append(this.eventDate.ToString("yyyy-MM-dd HH:mm:ss"));
            eventOutput.Append(" | " + this.eventTitle);
            if (this.eventLocation != null && this.eventLocation != string.Empty)
            {
                eventOutput.Append(" | " + this.eventLocation);
            }

            return eventOutput.ToString();
        }
    }
}