using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public abstract class Media
    {
        protected Media(long barcode, string title, string author, string publisher, MediaType type, int quanity)
        {
            this.Details.Barcode = barcode;
            this.Details.Title = title;
            this.Details.Author = author;
            this.Details.Publisher = publisher;
            this.Details.Type = type;
            this.Details.Quantity = quanity;
        }

        public MediaData Details { get; set; }
    }
}
