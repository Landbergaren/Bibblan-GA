using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class Book
    {
        private string title;
        private string author;
        private string genre;
        private int isbn;
        private bool availability;
        private string type;
        private int totalBooks = 0;
        private int pages = 0;

        static int isbnCounter = 1000;

        public string Title { get => title; set => title = value; }
        public string Author { get => author; set => author = value; }
        public string Genre { get => genre; set => genre = value; }
        public int Isbn { get => isbn; set => isbn = value; }
        public bool Availability { get => availability; set => availability = value; }
        public string Type { get => type; set => type = value; }
        public int TotalBooks { get => totalBooks; set => totalBooks = value; }
        public int Pages { get => pages; set => pages = value; }
        public string StringAvailability { get { if (availability == true) return "Yes"; else return "No"; } }


        public Book(string inTitle, string inAuthor, string ingenre, int intotalBooks, int inPages, bool availability)
        {
            isbnCounter++;

            Pages = inPages;
            Title = inTitle;
            Author = inAuthor;
            Genre = ingenre;
            Isbn = isbnCounter;
            TotalBooks = intotalBooks;
            Availability = availability;
        }
    }
}
