using System;
using System.Text;

namespace ElectronicLibrary
{
    public class Electronic : Media
    {
        public Electronic(string title, string author, string publisher, MediaType type, long barcode, int quantity, TimeSpan length)
            : base(title, author, publisher, type, barcode, quantity)
        {
            this.Length = length;
        }

        public TimeSpan Length { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format("Length: {0:hh:mm}\n", this.Length.ToString());
        }

        internal override string ToFileSave()
        {
            StringBuilder record = new StringBuilder();
            record.Append(base.ToFileSave());
            record.Append(this.Length.ToString() + "\t");
            return record.ToString();
        }
    }
}
