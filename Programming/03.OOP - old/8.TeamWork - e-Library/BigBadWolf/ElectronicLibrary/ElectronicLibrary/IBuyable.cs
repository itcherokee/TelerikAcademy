using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public interface IBuyable
    {
        decimal BuyPrice { get; set; }
        
        void Buy();
    }
}
