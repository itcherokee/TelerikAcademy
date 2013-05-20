namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Record : IComparable<Record>
    {
        public SortedSet<string> PhoneNumbers { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append('[');
            output.Append(this.Name);
            output.Append(": ");
            output.Append(string.Join(", ", this.PhoneNumbers));
            output.Append(']');
            return output.ToString();
        }

        public int CompareTo(Record other)
        {
            return this.Name.ToLowerInvariant().CompareTo(other.Name.ToLowerInvariant());
        }
    }
}
