using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Paper : Media
    {
        protected Paper(string title, string author, string publisher, MediaType type, long barcode, int quantity, int pages)
            : base(title, author, publisher, type, barcode, quantity)
        {
            this.Pages = pages;
        }

        public int Pages { get; set; }

        public override string ToString()
        {
            return base.ToString() + String.Format("Pages: {0}\n", this.Pages);
        }

        internal override string ToFileSave()
        {
            StringBuilder record = new StringBuilder();
            record.Append(base.ToFileSave());
            record.Append(this.Pages.ToString() + "\t");
            return record.ToString();
        }
    }
}
