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

        public Account(string name, string phonenumber, int age)
        {

        }

       public virtual void Rent()
        {

        }
    }

    class Adult : Account
    {
        bool vip;

        public Adult(string name, string phonenumber, int age, bool vip) : base(name, phonenumber, age)
        {
        }

        public override void Rent()
        {
            
        }


    }

    class Minor : Account
    {
        string parent;

        public Minor(string name, string phonenumber, int age, string parent) : base(name, phonenumber, age)
        {
        }
    }

}
