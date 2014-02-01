using System;
using System.Text;

namespace ElectronicLibrary
{
    public class Movie : Electronic, IRentable
    {
        public Movie(string title, string author, string publisher, long barcode, int quantity, TimeSpan length, decimal rentPrice, bool isRented = false)
            : base(title, author, publisher, MediaType.Movie, barcode, quantity, length)
        {
            this.RentPrice = rentPrice;
            this.IsRented = isRented;
        }

        #region IRentable Interface Members

        public decimal RentPrice { get; set; }

        public bool IsRented { get; set; }

        public void Rent()
        {
            this.IsRented = true;
            OnRented();
        }

        public void ReturnRented()
        {
            this.IsRented = false;
            //OnReturnRented();
        }

        #endregion

        #region Trigers for the event to be fired when Movie has been rented

        public event MovieRentedEventHandler MovieHasBeenRented;

        // fires the event in case of records change
        protected virtual void OnRented()
        {
            if (MovieHasBeenRented != null)
            {
                MovieHasBeenRented(this, "rented");
            }
        }

        #endregion

        public override string ToString()
        {
            return base.ToString() + String.Format("Rent price: {0:C}\n", this.RentPrice.ToString());
        }

        internal override string ToFileSave()
        {
            StringBuilder record = new StringBuilder();
            record.Append(base.ToFileSave());
            record.Append(this.RentPrice.ToString() + "\t");
            return record.ToString();
        }



    }
}
