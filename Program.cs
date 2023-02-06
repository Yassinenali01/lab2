
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>(); // this list would include anything has a type of employee including salaried and parttime...
            string path = "employees.txt";

            string[] lines = File.ReadAllLines(path);
            double averagePay = 0;
            foreach (string line in lines)
            {
                string[] cells = line.Split(':');


                string id = cells[0];
                string name = cells[1];
                string address = cells[2];

                string firstDigit = id.Substring(0, 1); // 0 is the index and 1 is the lenght

                /*if (firstDigit == "0" || firstDigit == "1" || firstDigit=="2" || firstDigit == "3" || firstDigit == "4")
                {

                }*/

                int firstDigitInt = int.Parse(firstDigit);

                if (firstDigitInt >= 0 && firstDigitInt <= 4)
                {
                    // if firstdigit between 0 and 4 it means salaried
                    string salary = cells[7];
                    double salaryDouble = double.Parse(salary);

                    Salaried salaried = new Salaried(id, name, address, salaryDouble); //// whyyyy
                    employees.Add(salaried);

                }
                else if (firstDigitInt >= 5 && firstDigitInt <= 7)
                {
                    // wage

                    string rate = cells[7];
                    string hours = cells[8];
                    double rateDouble = double.Parse(rate);
                    int hoursInt = int.Parse(hours);

                    Wages wages = new Wages(id, name, address, rateDouble,hoursInt );
                    employees.Add(wages);
                }
                else if (firstDigitInt >= 8 && firstDigitInt <= 9)
                {
                    // Part Time.
                    string rate = cells[7];
                    string hours = cells[8];

                    double rateDouble = double.Parse(rate);
                    int hoursInt = int.Parse(hours);

                    PartTime partTime = new PartTime(id, name, address, rateDouble, hoursInt);
                    employees.Add(partTime);

                }

                // average weekly pay for all employees.
                //double averagePay = 0;
                double totalSalary = 0;
                foreach (Employee employee in employees)
                {
                    
                    double weeklyPay = employee.GetWeeklyPay();
                    totalSalary+= weeklyPay;

                    /*double averagePay = totalSalary / employee.Count;*/

                }
                averagePay = totalSalary / employees.Count;

                //Console.WriteLine("the average pay for all the employees is " + averagePay);

            }
            Console.WriteLine("the average pay for all the employees is " + averagePay);


            //Console.WriteLine("the average pay for all the employees is " + averagePay);
            double highestWeeklyPay = 0;
            double lowestSalary = 10000000000000000;
            double weekPay = 0;
            string employeeNameWage = "";
            string employeeName = "";
            //int employeesNumber = 0;
            int WagesNumber = 0;
            int partTimeNumber = 0;
            int SalaryNumber = 0;
            double perWages = 0;
            double perSalary = 0;
            double perPartTime = 0;
            foreach(Employee employee in employees)
            {
                if (employee is Wages){
                    WagesNumber += 1;
                    weekPay = employee.GetWeeklyPay();
                    if (weekPay > highestWeeklyPay)
                    {
                        highestWeeklyPay = weekPay;
                        employeeNameWage = employee.Name;
                        
                    }
                    

                }
                else if (employee is Salaried)
                {
                    SalaryNumber += 1;
                    weekPay = employee.GetWeeklyPay();
                    if (weekPay < lowestSalary)
                    {
                        lowestSalary = weekPay;
                        employeeName = employee.Name;
                        
                    }
                    

                }
                else if (employee is PartTime) 
                {
                    partTimeNumber += 1;
                
                }
                /*perWages = WagesNumber / employees.Count * 100;
                perSalary = SalaryNumber / employees.Count * 100;
                perPartTime = partTimeNumber / employees.Count * 100;*/





            }
            perWages = (double) WagesNumber / employees.Count * 100;
            perSalary = (double) SalaryNumber / employees.Count * 100;
            perPartTime = (double) partTimeNumber / employees.Count * 100;


            Console.WriteLine("The highest weekly pay for "+employeeNameWage +"the Wages is" + highestWeeklyPay);
            Console.WriteLine("The Lowest salary pay is " + lowestSalary + "and the name is " + employeeName);

            Console.WriteLine("The percentage of the Wages employees is " + perWages + "%");
            Console.WriteLine("The percentage of the Salary employees is " + perSalary + "%");

            Console.WriteLine("The percentage of the part Time employees is " + perPartTime + "%");



        }

    }
}
