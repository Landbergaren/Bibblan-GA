using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class Account
    {
        private static List<Account> list = BuildMemberList();
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

        private static List<Account> BuildMemberList()
        {
            List<Account> Members = new List<Account>();
            Members.Add(new Account("Steve Jobs", "666-666", 50, "Apple", "Apple"));
            Members.Add(new Account("Steve Jobs", "666-666", 50, "Banana", "Banana"));
            Members.Add(new Account("Steve Jobs", "666-666", 50, "Peach", "Peach"));
            Members.Add(new Account("Steve Jobs", "666-666", 5, "Broccoli", "Broccoli"));
            Members.Add(new Account("Steve Jobs", "666-666", 12, "Potato", "Potato"));
            Members.Add(new Account("Steve Jobs", "666-666", 10, "Onion", "Onion"));

            return Members;
        }

        public static bool LogIn(string username, string password)
        {
            bool matchfound = false;
            foreach (var members in list)
            {
                if (members.Username == username && members.Password == password)
                {
                    matchfound = true;
                    return matchfound;
                }
            }
                return matchfound;
        }
    }
}
