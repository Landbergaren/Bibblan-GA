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
            Books.Add(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Fiction", 3, 250, false));
            Books.Add(new Book("Nineteen Eighty-Four", "George Orwell", "Fiction", 4, 160, true));
            Books.Add(new Book("Origin", "Dan Brown", "Fiction", 3, 356, false));
            Books.Add(new Book("To Kill a Mockingbird", "Harper Lee", "Fiction", 5, 250, true));


            Books.Add(new Book("Harry Potter and the Philosophers Stone", "J.K Rowling", "Fantasy", 1, 225, false));
            Books.Add(new Book("Game of Thrones", "George R.R Martin", "Fantasy", 2, 231, true));
            Books.Add(new Book("The Hobbit", "J.R.R Tolkien", "Fantasy", 3, 405, false));
            Books.Add(new Book("Sword of Shannara", "Terry Brooks", "Fantasy", 2, 210, true));

            Books.Add(new Book("Pride and Prejudice", "Jane Austen", "Romance", 3, 250, false));
            Books.Add(new Book("Fifty Shades of Grey", "E.L James", "Romance", 3, 250, true));
            Books.Add(new Book("Wallbanger", "Alice Clayton", "Romance", 3, 250, false));
            Books.Add(new Book("Twilight", "Stephenie Meyer", "Fiction", 3, 250, true));

            Books.Add(new Book("Steve Jobs", "Walter Isaacson", "Biography", 3, 250, false));
            Books.Add(new Book("The Diary of Anne Frank", "Anne Frank", "Biography", 3, 250, true));
            Books.Add(new Book("Dreams from My Father", "Barack Obama", "Biography", 3, 250, false));
            Books.Add(new Book("Finding My Virginity", "Richard Branson", "Biography", 3, 250, true));

            return Books;
        }

        public static List<Account> BuildMemberList()
        {
            List<Account> Members = new List<Account>();
            Members.Add(new Adult("Steve Jobs", "666-666", 50, true));

            return Members;
        }
    }
}
