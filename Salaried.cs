using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Salaried : Employee 
    {
        private double salary;

        //properties 
        public double Salary { get { return salary; } }

        public Salaried (string id, string name, string address, double salary) // : base (id, name,address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.salary = salary;
        }

        public override double GetWeeklyPay()
        {
            return salary;
        }


    }
}
