using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Paper : Media
    {
        public Paper(long barcode, string title, string author, string publisher, MediaType type, int quantity) 
            : base(barcode, title, author, publisher, type, quantity)
        {
        }
    }
}
