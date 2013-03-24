using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Music : Electronic, IBuyable
    {
        public Music(long barcode, string title, string author, string publisher, MediaType type, int quantity, int length)
            : base(barcode, title, author, publisher, type, quantity, length)
        {
        }

        #region IBuyable Members


        public decimal BuyPrice { get; set; } 
        #endregion
    }
}
