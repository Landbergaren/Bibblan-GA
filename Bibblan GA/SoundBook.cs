using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibblan_GA
{
    class SoundBook : Item
    {
        private string type;

        public SoundBook(string inName, string inAuthor, string ingenre) : base(inName, inAuthor, ingenre)
        {
            type = "soundbook";

        }

        public override void Rent(string customerName, int customerAge)
        {
            base.Rent(customerName, customerAge);
        }
    }
}
