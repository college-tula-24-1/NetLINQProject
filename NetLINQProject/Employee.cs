using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLINQProject
{
    class Employee
    {
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, Birth Date: {BirthDate.ToShortDateString()}, Salary: {Salary}";
        }

        public static List<Employee> ListInit()
        {
            List<Employee> employees = new()
            {
                new()
                {
                    Name = "Tommy",
                    BirthDate = new DateTime(1995, 10, 24),
                    Salary = 120000M
                },

                new()
                {
                    Name = "Jimmy",
                    BirthDate = new DateTime(1989, 5, 11),
                    Salary = 135000M
                },

                new()
                {
                    Name = "Bobby",
                    BirthDate = new DateTime(2001, 7, 30),
                    Salary = 90000M
                },

                new()
                {
                    Name = "Kenny",
                    BirthDate = new DateTime(1997, 11, 6),
                    Salary = 110000M
                },

                new()
                {
                    Name = "Timmy",
                    BirthDate = new DateTime(1993, 9, 14),
                    Salary = 115000M
                },

                new()
                {
                    Name = "Mikky",
                    BirthDate = new DateTime(2000, 5, 17),
                    Salary = 100000M
                },
            };
            
            return employees;
        }
    }

    class City
    {
        public string Title { get; set; } = null!;
        public override string ToString()
        {
            return $"City: {Title}";
        }

        public static List<City> ListInit()
        {
            List<City> cities = new()
            {
                new(){ Title = "Moscow" },
                new(){ Title = "St. Petersburg" },
                new(){ Title = "Kazan" },
            };
            return cities;
        }
    }
}
