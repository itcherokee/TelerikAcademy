using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public interface IRentable
    {
        event EventHandler Rented;
        
        decimal Price { get; set; }
        
        void Rent();
    }
}
