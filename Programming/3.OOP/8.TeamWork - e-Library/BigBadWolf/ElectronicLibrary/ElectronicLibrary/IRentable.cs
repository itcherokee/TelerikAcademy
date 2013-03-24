using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public delegate void BookRentedEventHandler(Media media, string operation);

    public delegate void MovieRentedEventHandler(Media media,string operation);

    public interface IRentable
    {
        decimal RentPrice { get; set; }

        bool IsRented { get; set; }

        void Rent();

        void ReturnRented();
    }
}
