using Lab2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Employee
    {
        protected string id; // protected means every sub class/ child class can access this field.
        protected string name;
        protected string address;

        // properties
        public string Id { get => id; } // we're not using set cuz we're not changing any employee info.
        public string Name { get => name;  }
        public string Address { get => address;  }

        // no arg constructor

        public Employee() { }

        // constructor

        public Employee(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }
        // If there is no constructor one will be created by default.


        public virtual double GetWeeklyPay()
        {
            return 0;
        }


    }
}
