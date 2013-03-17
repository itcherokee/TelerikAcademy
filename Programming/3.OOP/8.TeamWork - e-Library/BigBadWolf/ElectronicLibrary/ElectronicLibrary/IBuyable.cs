using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public interface IBuyable
    {
        event EventHandler Bought;
        
        decimal Price { get; set; }
        
        void Buy();
    }
}
