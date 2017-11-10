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

        static int isbnCounter = 1000;

        public Item(string inTitle, string inAuthor, string ingenre)
        {
            isbnCounter++;

            title = inTitle;
            author = inAuthor;
            genre = ingenre;
            isbn = isbnCounter;
            availability = true;
        }
        public virtual void Rent(string customerName, int customerAge)
        {

        }

    }
}
