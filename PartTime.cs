using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class PartTime : Employee
    {
        private double rate;
        private int hour;

        //properties

        public double Rate { get => rate; set => rate = value; }
        public int Hour
        {
            get => hour;

        }

        public PartTime (string id, string name, string address, double rate, int hour)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hour = hour;
        }

        public override double GetWeeklyPay() 
        { 
            double weeklyTotal = this.rate * this.hour;
            return weeklyTotal;
        }


    }
}
