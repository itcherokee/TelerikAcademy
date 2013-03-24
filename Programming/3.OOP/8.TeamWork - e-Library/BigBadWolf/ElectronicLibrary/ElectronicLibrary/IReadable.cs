using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public delegate void BookViewedEventHandler(Media media);

    public delegate void MagazineViewedEventHandler(Media media);

    public delegate void NewspaperViewedEventHandler(Media media);

    public interface IReadable
    {
        bool IsViewed { get; set; }

        void View();

        void ReturnViewed();
    }
}
