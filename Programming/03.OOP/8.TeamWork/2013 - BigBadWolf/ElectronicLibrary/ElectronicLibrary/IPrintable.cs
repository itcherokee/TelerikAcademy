using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public interface IPrintable
    {
        string Owner { get; set; }

        string Manager { get; set; }
        
        string ChiefEditor { get; set; }
    }
}
