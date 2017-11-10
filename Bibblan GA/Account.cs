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

        public Adult()
        {
            
        }
    }

    class Minor : Account
    {
        string parent;

        public Minor()
        {

        }
    }

}
