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
            books.Add(new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"));
        }
            
        //List<Item> books = new List<Item>
        //{
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //    new Book("the Great Gatsby", "F. Scott Fitzgerald", "Fiction"),
        //};
    }
}
