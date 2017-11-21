using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    abstract class Account
    {
        string name;
        string phonenumber;
        int age;
        string username;
        string password;

        public Account(string name, string phonenumber, int age, string username, string password)
        {
            Name = name;
            Phonenumber = phonenumber;
            Age = age;
            Username = username;
            Password = password;
        }

        public string Name { get => name; set => name = value; }
        public string Phonenumber { get => phonenumber; set => phonenumber = value; }
        public int Age { get => age; set => age = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public virtual void Rent(bool available)
        {

        }
    }

    class Adult : Account
    {
        bool vip;

        public Adult(string name, string phonenumber, int age, bool vip, string username, string password) : base(name, phonenumber, age, username, password)
        {
            Name = name;
            Phonenumber = phonenumber;
            Age = age;
            Username = username;
            Password = password;

        }

        public override void Rent(bool available)
        {
            
        }


    }

    class Minor : Account
    {
        string parent;

        public Minor(string name, string phonenumber, int age, string parent, string username, string password) : base(name, phonenumber, age, username, password)
        {
        }
    }

    class Worker : Account
    {
        public Worker(string name, string phonenumber, int age, string username, string password) : base(name, phonenumber, age, username, password)
        {
        }

        public Book AddBook(string title, string author, string genre, int totalBooks, int pages, bool available)
        {
          Book NewBook = new Book(title, author, genre, totalBooks, pages, available);
            return NewBook;
        }
    }
}
