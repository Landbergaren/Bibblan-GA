using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class Library
    {
        List<Item> books;

        public Library()
        {
            books = new List<Item>();
            books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            books.Add(new Book("Harry Potter and the Philosophers Stone", "J.K Rowling", "Fantasy", 3, 200));
            books.Add(new Book("fjdslldsf", "iosdrse", "haha", 51, 231));
            books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
            books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250));
        }
    }
}
