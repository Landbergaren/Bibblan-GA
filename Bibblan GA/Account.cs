using System.Collections.Generic;
using System.Windows;

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
            this.name = name;
            this.phonenumber = phonenumber;
            this.age = age;
            this.username = username;
            this.password = password;
        }

        public string Name { get => name; }
        public string Phonenumber { get => phonenumber; }
        public int Age { get => age; }
        public string Username { get => username; }
        public string Password { get => password; }

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

        public static bool LogIn(string usernameInput, string passwordInput)
        {
            bool matchfound = false;
            foreach (var member in list)
            {
                if (member.Username == usernameInput && member.Password == passwordInput)
                {
                    MessageBox.Show("Successfully logged in!");
                    return matchfound = true;
                }
            }
            MessageBox.Show("Username or password incorrect!");
            return matchfound;
        }
    }
}
