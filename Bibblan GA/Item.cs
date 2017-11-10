using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    abstract class Item
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

        public Item(string inTitle, string inAuthor, string ingenre, int intotalBooks, int inPages)
        {
            isbnCounter++;

            pages = inPages;
            title = inTitle;
            author = inAuthor;
            genre = ingenre;
            isbn = isbnCounter;
            totalBooks = intotalBooks;
            availability = true;
        }
    }
}
