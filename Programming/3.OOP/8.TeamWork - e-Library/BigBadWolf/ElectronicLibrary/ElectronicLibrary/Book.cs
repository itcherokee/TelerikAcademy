using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ElectronicLibrary
{
    public class Book : Paper, IReadable, IBuyable, IRentable
    {
        public int ISBN { get; private set; }
        public int Year { get; private set; }
        public int Pages { get; private set; }

        public Book(long barcode, string title, string author, string publisher, MediaType type, int quantity, int ISBN, int year, int pages)
            : base(barcode, title, author, publisher, type, quantity)
        {
            this.ISBN = ISBN;
            this.Year = year;
            this.Pages = pages;
        }

        public Book(long barcode, string title, string author)
            : this(barcode, title, author, null, MediaType.Book, 0, 0, 0, 0)
        {
        }

        public Book(long barcode, string title)
            : this(barcode, title, null)
        {
        }

        //public Book (string title, string author, string publisher, decimal price, int ISDN, int year, int page)
        //{
        //    MediaData mediaBook = new MediaData();

        //    mediaBook.Title= title;
        //    mediaBook.Author = author;
        //    mediaBook.Publisher = publisher;
        //    mediaBook.Price = price;
        //    mediaBook.Type = MediaType.Book;
        //    this.ISBN = ISDN;
        //    this.Year = year;
        //    this.Pages = page;
        //}

        //public Book(string title, string author)
        //{
        //    MediaData mediaBook = new MediaData();

        //    mediaBook.Title = title;
        //    mediaBook.Author = author;
        //}

        //public Book(string title)
        //{
        //    MediaData mediaBook = new MediaData();

        //    mediaBook.Title = title;
        //}

        //public Book(string title, string author)
        //{
        //    MediaData mediaBook = new MediaData();

        //    mediaBook.Author = author;
        //}

        #region IReadable Members
        public event EventHandler Viewed;

        public void View()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBuyable Members

        public event EventHandler Bought;

        public decimal IBuyable.Price { get; set; }

        public void Buy()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IRentable Members

        public event EventHandler Rented;

        public decimal IRentable.Price { get; set; }

        public void Rent()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
