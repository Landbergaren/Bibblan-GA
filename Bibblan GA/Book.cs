using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class Book : Item
    {
        string type;

        public Book(string inName, string inAuthor, string ingenre, int intotalBooks, int inPages) : base(inName, inAuthor, ingenre, intotalBooks, inPages)
        {
            type = "book";
        }
    }
}
