using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class PeriodicPress : Paper, IPrintable
    {
        public PeriodicPress(string title, string author, string publisher, MediaType media, long barcode, int quantity, int pages, string isbn, DateTime year,
             int volume = 0, string owner = "-none-", string manager = "-none-", string chiefEditor = "-none-")
            : base(title, author, publisher, media, barcode, quantity, pages)
        {
            this.Volume = volume;
            this.Owner = owner;
            this.Manager = manager;
            this.ChiefEditor = chiefEditor;
        }

        public int Volume { get; set; }

        #region IPrintableMedia Members

        public string Owner { get; set; }

        public string Manager { get; set; }

        public string ChiefEditor { get; set; }

        #endregion

        public override string ToString()
        {
            return base.ToString() + String.Format("Volume: {0}\nOwner: {1}\nManager: {2}\nChiefEditor: {3}",
                (this.Volume == 0) ? "-none-" : this.Volume.ToString(), this.Owner, this.Manager, this.ChiefEditor);
        }

        internal override string ToFileSave()
        {
            StringBuilder record = new StringBuilder();
            record.Append(base.ToFileSave());
            record.Append(this.Volume.ToString() + "\t");
            record.Append(this.Owner + "\t");
            record.Append(this.Manager + "\t");
            record.Append(this.ChiefEditor + "\t");
            return record.ToString();
        }
    }
}
