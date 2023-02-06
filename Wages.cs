using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Wages : Employee
    {
        private double rate;
        private double hour;

        //properties

        public double Rate { get => rate; set => rate = value; }
        public double Hour
        {
            get => hour;
        }

        public Wages (string id, string name, string address, double rate, double hour)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.rate = rate;
            this.hour = hour;
        }
        public override double GetWeeklyPay()
        {
            double weeklyTotal = 0;
            if (hour <= 40)
            { 
                weeklyTotal = this.rate * this.hour;
                
                
            } else 
            {
                double overTime = 0;
                overTime = hour - 40;
                weeklyTotal = this.rate * this.hour;
                double overTimeTotal = overTime * (this.rate * 1.5);
                weeklyTotal +=  overTimeTotal;
                
            }

            return weeklyTotal;
           
        }

    }
}
