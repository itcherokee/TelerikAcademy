using System;
using System.Text;

namespace ElectronicLibrary
{
    public abstract class Media
    {
        public int Quantity { get; set; }

        public MediaData Details { get; set; }

        public Media(string title, string author, string publisher, MediaType type, long barcode, int quantity)
        {
            MediaData details = new MediaData();
            details.Type = type;
            details.Title = title;
            details.Author = author;
            details.Barcode = barcode;
            details.Publisher = publisher;
            this.Details = details;
            this.Quantity = quantity;
        }

        public override string ToString()
        {
            return String.Format("Barcode: {0}\nTitle: {1}\nAuthor: {2}\nPublisher: {3}\nType: {4}\nQuantity: {5}",
                this.Details.Barcode, this.Details.Title, this.Details.Author, this.Details.Publisher, this.Details.Type, this.Quantity);
        }

        internal virtual string ToFileSave()
        {
            StringBuilder record = new StringBuilder();
            record.Append(this.Details.Type.ToString() + "\t");
            record.Append(this.Details.Title + "\t");
            record.Append(this.Details.Author + "\t");
            record.Append(this.Details.Barcode.ToString() + "\t");
            record.Append(this.Details.Publisher + "\t");
            record.Append(this.Quantity.ToString() + "\t");
            return record.ToString();
        }
    }
}
