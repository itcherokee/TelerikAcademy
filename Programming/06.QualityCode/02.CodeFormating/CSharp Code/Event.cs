namespace CSharpCode
{
    using System;
    using System.Text;

    public class Event : IComparable
    {
        public Event(DateTime date, string title, string location)
        {
            this.Date = date;
            this.Title = title;
            this.Location = location;
        }

        public string Location { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public int CompareTo(object obj)
        {
            var other = obj as Event;
            if (other != null)
            {
                int compareByDate = this.Date.CompareTo(other.Date);
                int compareByTitle = string.Compare(this.Title, other.Title, StringComparison.Ordinal);
                int compareByLocation = string.Compare(this.Location, other.Location, StringComparison.Ordinal);
                if (compareByDate == 0)
                {
                    if (compareByTitle == 0)
                    {
                        return compareByLocation;
                    }

                    return compareByTitle;
                }

                return compareByDate;
            }

            throw new ArgumentNullException("obj", "Argument cannot be null!");
        }

        public override string ToString()
        {
            var output = new StringBuilder();
            output.Append(this.Date.ToString("yyyy-MM-ddTHH:mm:ss"));
            output.Append(" | " + this.Title);
            if (!string.IsNullOrEmpty(this.Location))
            {
                output.Append(" | " + this.Location);
            }

            return output.ToString();
        }
    }
}