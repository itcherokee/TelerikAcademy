using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Music : Electronic, IBuyable
    {
        public Music(long barcode, string title, string author, string publisher, MediaType type, int quantity)
            : base(barcode, title, author, publisher, type, quantity)
        {
        }

        #region IBuyable Members
        public event EventHandler Bought;

        public decimal IBuyable.Price { get; set; }

        public void Buy()
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
