using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public interface IReadable
    {
        event EventHandler Viewed;
    
        void View();
    }
}
