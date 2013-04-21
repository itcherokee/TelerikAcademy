namespace CSharpEvents
{
    using System;
    using System.Text;

    internal class Event : IComparable
    {
        private readonly DateTime eventDate;
        private readonly string eventTitle;
        private readonly string eventLocation;

        public Event(DateTime date, string title, string location)
        {
            this.eventDate = date;
            this.eventTitle = title;
            this.eventLocation = location;
        }

        public int CompareTo(object eventToCompare)
        {
            Event comparedEvent = eventToCompare as Event;
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
            eventOutput.Append(this.eventDate.ToString("yyyy-MM-ddTHH:mm:ss"));
            eventOutput.Append(" | " + this.eventTitle);
            if (this.eventLocation != null && this.eventLocation != string.Empty)
            {
                eventOutput.Append(" | " + this.eventLocation);
            }

            return eventOutput.ToString();
        }
    }
}