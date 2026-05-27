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
        public Company? Company { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, " +
                $"Birth Date: {BirthDate.ToShortDateString()}, " +
                $"Salary: {Salary}, " +
                $"Company: {Company}";
        }

        public static List<Employee> ListInit()
        {
            var companies = CompaniesInit();

            List<Employee> employees = new()
            {
                new()
                {
                    Name = "Tommy",
                    BirthDate = new DateTime(1995, 10, 24),
                    Salary = 120000M,
                    Company = companies[0],
                },

                new()
                {
                    Name = "Jimmy",
                    BirthDate = new DateTime(1989, 5, 11),
                    Salary = 135000M,
                    Company = companies[1],
                },

                new()
                {
                    Name = "Bobby",
                    BirthDate = new DateTime(2001, 7, 30),
                    Salary = 90000M,
                    Company = companies[2],
                },

                new()
                {
                    Name = "Kenny",
                    BirthDate = new DateTime(1997, 11, 6),
                    Salary = 110000M,
                    Company = companies[3],
                },

                new()
                {
                    Name = "Timmy",
                    BirthDate = new DateTime(1993, 9, 14),
                    Salary = 115000M,
                    Company = companies[0],
                },

                new()
                {
                    Name = "Mikky",
                    BirthDate = new DateTime(2000, 5, 17),
                    Salary = 100000M,
                    Company = companies[3],
                },

                new()
                {
                    Name = "Tommy",
                    BirthDate = new DateTime(1989, 9, 12),
                    Salary = 140000M,
                    Company = companies[0],
                },

                new()
                {
                    Name = "Jimmy",
                    BirthDate = new DateTime(2001, 3, 8),
                    Salary = 90000M,
                    Company = companies[1],
                },

                new()
                {
                    Name = "Bobby",
                    BirthDate = new DateTime(1999, 12, 7),
                    Salary = 111000M,
                    Company = companies[0],
                },

                new()
                {
                    Name = "Kenny",
                    BirthDate = new DateTime(1993, 5, 16),
                    Salary = 110000M,
                    Company = companies[1],
                },

                new()
                {
                    Name = "Timmy",
                    BirthDate = new DateTime(2000, 8, 22),
                    Salary = 125000M,
                    Company = companies[2],
                },

                new()
                {
                    Name = "Mikky",
                    BirthDate = new DateTime(1993, 11, 27),
                    Salary = 80000M,
                    Company = companies[0],
                },
            };
            
            return employees;
        }

        public static List<Company> CompaniesInit()
        {
            List<Company> companies = new()
            {
                new(){ Title = "Yandex", City = new(){ Title = "Moscow" } },
                new(){ Title = "Ozon", City = new(){ Title = "St. Petersburg" } },
                new(){ Title = "Mail Group", City = new(){ Title = "Moscow" } },
                new(){ Title = "Sberbank", City = new(){ Title = "Kazan" } },
            };
            return companies;
        }
    }

    class Company
    {
        public string Title { get; set; } = null!;
        public City? City { get; set; }
        public override string ToString()
        {
            return $"Title: {Title}";
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
