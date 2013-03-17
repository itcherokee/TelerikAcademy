using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Newspaper : Paper, IReadable, IBuyable, IPrintableMedia
    {
        public Newspaper(long barcode, string title, string author, string publisher, MediaType type, int volume, int quantity, string owner, string manager, string chiefEditor)
            : base(barcode, title, author, publisher, type, quantity)
        {
            this.Volume = volume;
            this.Owner = owner;
            this.Manager = manager;
            this.ChiefEditor = chiefEditor;
        }

        public int Volume { get; set; }

        #region IReadable Members
        public event EventHandler Viewed;

        public void View()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBuyable Members

        public event EventHandler Bought;
        
        public decimal IBuyable.Price { get; set; }
        
        public void Buy()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IPrintableMedia Members
        public string Owner { get; set; }

        public string Manager { get; set; }

        public string ChiefEditor { get; set; }
        #endregion
    }
}
