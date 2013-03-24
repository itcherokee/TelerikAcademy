using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Newspaper : PeriodicPress, IReadable
    {
        public Newspaper(string title, string author, string publisher, long barcode, int quantity, int pages, string isbn, DateTime year, bool isViewed = false,
            int volume = 0, string owner = "-none-", string manager = "-none-", string chiefEditor = "-none-")
            : base(title, author, publisher, MediaType.Newspaper, barcode, quantity, pages, isbn, year, volume, owner, manager, chiefEditor)
        {
            this.IsViewed = isViewed;
        }

        #region IReadable Members

        public bool IsViewed { get; set; }

        public void View()
        {
            this.IsViewed = true;
            OnViewed();
        }

        public void ReturnViewed()
        {
            this.IsViewed = false;
            // TODO: OnReturnViewed();
        }

        #endregion

        #region Trigers for the event to be fired when Book has been taken to be read

        public event NewspaperViewedEventHandler NewspaperHasBeenRead;

        // fires the event in case of records change
        protected virtual void OnViewed()
        {
            if (NewspaperHasBeenRead != null)
            {
                NewspaperHasBeenRead(this);
            }
        }

        #endregion
    }
}
