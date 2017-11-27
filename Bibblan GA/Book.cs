using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    public class Book
    {
        private string title;
        private string author;
        private string genre;
        private int isbn;
        private bool availability;
        private int totalBooks;
        private int pages = 0;
        private string bookInfo;
        private static int isbnCounter = 1000;

        public string Title { get => title; }
        public string Author { get => author; }
        public string Genre { get => genre; }
        public int Isbn { get => isbn; }
        public bool Availability { get => availability; }
        public int TotalBooks { get { return totalBooks; } set { totalBooks = value; if (value <= 0) availability = false; } }
        public int Pages { get => pages; }
        public string StringAvailability { get { if (availability == true) return "Yes"; else return "No"; } }
        public string BookInfo { get => bookInfo; }

        public Book(string inTitle, string inAuthor, string ingenre, int intotalBooks, int inPages, bool availability, string bookinfo)
        {
            isbnCounter++;

            this.pages = inPages;
            this.title = inTitle;
            this.author = inAuthor;
            this.genre = ingenre;
            this.isbn = isbnCounter;
            this.totalBooks = intotalBooks;
            this.availability = availability;
            this.bookInfo = bookinfo;
        }
    }
}
