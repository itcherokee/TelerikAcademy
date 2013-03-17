using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public struct MediaData
    {
        public long Barcode { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Quantity { get; set; }
        public MediaType Type { get; set; }
    }
}
