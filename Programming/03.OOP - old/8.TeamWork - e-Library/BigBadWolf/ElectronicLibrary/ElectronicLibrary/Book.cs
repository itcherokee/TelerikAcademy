using System;
using System.Text;

namespace ElectronicLibrary
{
    public class Book : Paper, IReadable, IRentable
    {
        public Book(string title, string author, string publisher, long barcode, int quantity, int pages, string isbn, DateTime year, bool isRented = false)
            : base(title, author, publisher, MediaType.Book, barcode, quantity, pages)
        {
            this.ISBN = isbn;
            this.Year = year;
            this.IsRented = isRented;
        }

        public string ISBN { get; private set; }

        public DateTime Year { get; private set; }

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

        #region IRentable Members

        public bool IsRented { get; set; }

        public decimal RentPrice { get; set; }

        public void Rent()
        {
            this.IsRented = true;
            OnRented();
        }

        public void ReturnRented()
        {
            this.IsRented = false;
            // TODO: OnReturnRented();
        }

        #endregion

        #region Trigers for the event to be fired when Book has been rented

        public event BookRentedEventHandler BookHasBeenRented;

        // fires the event in case of records change
        protected virtual void OnRented()
        {
            if (BookHasBeenRented != null)
            {
                BookHasBeenRented(this, "rented");
            }
        }

        #endregion

        #region Trigers for the event to be fired when Book has been taken to be read

        public event BookViewedEventHandler BookHasBeenRead;

        // fires the event in case of records change
        protected virtual void OnViewed()
        {
            if (BookHasBeenRead != null)
            {
                BookHasBeenRead(this);
            }
        }

        #endregion

        public override string ToString()
        {
            return base.ToString() + String.Format("ISBN: {0}\nYear: {1:YYYY}\nRent price: {2}", this.ISBN.ToString(), this.Year.Year.ToString(), this.RentPrice.ToString());
        }

        internal override string ToFileSave()
        {
            StringBuilder record = new StringBuilder();
            record.Append(base.ToFileSave());
            record.Append(this.ISBN + "\t");
            record.Append(this.Year.Year.ToString() + "\t");
            record.Append(this.RentPrice.ToString() + "\t");
            return record.ToString();
        }
    }
}
