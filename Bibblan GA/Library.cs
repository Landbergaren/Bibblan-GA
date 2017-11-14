using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class Library
    {

        public static List<Book> BuildLibrary()
        {
            List<Book> Books = new List<Book>();
            Books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            Books.Add(new Book("Harry Potter and the Philosophers Stone", "J.K Rowling", "Fantasy", 3, 200));
            Books.Add(new Book("fjdslldsf", "iosdrse", "haha", 51, 231));
            Books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            Books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            Books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            Books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            Books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            return Books;
        }
    }
}
