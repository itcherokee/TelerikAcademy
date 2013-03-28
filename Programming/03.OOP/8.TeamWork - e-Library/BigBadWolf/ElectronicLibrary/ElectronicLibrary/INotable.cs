using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    // used to implement Notes behavior
    public interface INotable
    {
        string Notes { get; set; }  

        /// <summary>
        /// Reset / Clears the content of Notes
        /// </summary>
        void Reset();


    }

  
}
