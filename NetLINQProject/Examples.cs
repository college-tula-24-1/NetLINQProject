using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLINQProject
{
    class CityNameLengthComparer : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            int xLength = x?.Length ?? 0;
            int yLength = y?.Length ?? 0;
            return xLength - yLength;
        }
    }

    static class Examples
    {
        public static void LinqWelcomeExample()
        {
            string[] names = { "Bobby", "Sammy", "Jonny", "Benny", "Jimmy", "Tommy" };

            List<string> jNames = new();

            foreach (string name in names)
                if (name.TrimStart().ToUpper().StartsWith("J"))
                    jNames.Add(name);

            jNames.Sort();

            foreach (string name in jNames)
                Console.WriteLine(name);
            Console.WriteLine();

            /* 
             * LINQ to Object 
             * 
             * Query operators
             * Extensions Methods
             * 
             */

            /* Query operators */
            var jNamesOperators = from name in names
                                  where name.Trim().ToUpper().StartsWith("J")
                                  orderby name
                                  select name;

            foreach (string name in jNamesOperators)
                Console.WriteLine(name);
            Console.WriteLine();

            /* Extensions Methods */
            var jNamesMethods = names.Where(name => name.Trim().ToUpper().StartsWith("J"))
                                     .OrderBy(name => name)
                                     .Select(name => name);

            foreach (string name in jNamesMethods)
                Console.WriteLine(name);
            Console.WriteLine();
        }

        public static void LinqSelectExample()
        {
            var employees = Employee.ListInit();

            var namesOpers = from e in employees
                             select e.Name;
            foreach (var name in namesOpers)
                Console.WriteLine(name);
            Console.WriteLine();

            var namesMethods = employees.Select(e => e.Name);
            foreach (var name in namesMethods)
                Console.WriteLine(name);
            Console.WriteLine();


            var personsOpers = from e in employees
                               select new
                               {
                                   Name = e.Name,
                                   Age = DateTime.Now.Year - e.BirthDate.Year,
                               };
            foreach (var person in personsOpers)
                Console.WriteLine(person);
            Console.WriteLine();

            var personsMethods = employees.Select(e =>
                new
                {
                    Name = e.Name,
                    Age = DateTime.Now.Year - e.BirthDate.Year,
                });

            foreach (var person in personsMethods)
                Console.WriteLine(person);
            Console.WriteLine();


            var cities = City.ListInit();

            var namesCitiesOpers = from e in employees
                                   from c in cities
                                   select new
                                   {
                                       e.Name,
                                       City = c.Title
                                   };
            foreach (var nc in namesCitiesOpers)
                Console.WriteLine(nc);
            Console.WriteLine();

            var namesCitiesMethods = employees.SelectMany(
                e => cities,
                (e, c) => new
                {
                    e.Name,
                    City = c.Title
                });

            foreach (var nc in namesCitiesMethods)
                Console.WriteLine(nc);
            Console.WriteLine();
        }

        public static void LinqFiltersWhereExample()
        {
            var employees = Employee.ListInit();

            var oldsOpers = from e in employees
                                //where e.BirthDate.Year < 2000
                            where e.BirthDate.Year < 2000 &&
                                    e.Name.StartsWith("T")
                            select new
                            {
                                e.Name,
                                Age = DateTime.Now.Year - e.BirthDate.Year,
                            };
            //select e;
            foreach (var old in oldsOpers)
                Console.WriteLine(old);
            Console.WriteLine();


            var oldsMethods = employees.Where(e => e.BirthDate.Year < 2000 && e.Name.StartsWith("T"))
                                       //Where(e => e.BirthDate.Year < 2000)
                                       .Select(e => new
                                       {
                                           e.Name,
                                           Age = DateTime.Now.Year - e.BirthDate.Year,
                                       });
            foreach (var old in oldsMethods)
                Console.WriteLine(old);
            Console.WriteLine();

            //

            List<Shape> shapes = new()
            {
                new Shape(),
                new Circle(),
                new Rectangle(),
                new Shape(),
                new Circle(),
                new Rectangle(),
            };

            var circles = shapes.Where(sh => sh is Shape);
            //shapes.OfType<Shape>();
            foreach (var circle in circles)
                Console.WriteLine($"Type: {circle.GetType()}, Code: {circle.GetHashCode()}");
            Console.WriteLine();
        }

        public static void LinqSortExample()
        {
            Random random = new Random();
            List<int> numbers = new();
            for (int i = 0; i < 10; i++) numbers.Add(random.Next(0, 99));
            foreach (var number in numbers) Console.Write($"{number} ");
            Console.WriteLine();

            var orderNumbersOpers = from n in numbers
                                    orderby n
                                    select n;
            foreach (var number in orderNumbersOpers) Console.Write($"{number} ");
            Console.WriteLine();

            var orderNumbersMethods = numbers.OrderBy(n => n);
            foreach (var number in orderNumbersMethods) Console.Write($"{number} ");
            Console.WriteLine();


            var employees = Employee.ListInit();
            foreach (var e in employees)
                Console.WriteLine(e);
            Console.WriteLine();

            var orderEmployeesOpers = from e in employees
                                          //orderby e.Name
                                          //orderby e.BirthDate
                                      orderby e.Salary descending
                                      select e;
            foreach (var e in orderEmployeesOpers)
                Console.WriteLine(e);
            Console.WriteLine();

            var orderEmployeesMethods = employees.
                                                //OrderByDescending(e => e.Name);
                                                //OrderBy(e => e.BirthDate);
                                                OrderBy(e => e.Name);
            foreach (var e in orderEmployeesMethods)
                Console.WriteLine(e);
            Console.WriteLine();


            var orderEmployeesNameAgeOpers = from e in employees
                                             //orderby e.Name, e.BirthDate
                                             orderby e.Name descending, e.BirthDate
                                             select e;
            foreach (var e in orderEmployeesNameAgeOpers)
                Console.WriteLine(e);
            Console.WriteLine();

            var orderEmployeesNameAgeMethods = employees.OrderByDescending(e => e.Name)
                                                        //.OrderBy(e => e.Name)
                                                        .ThenBy(e => e.Salary)
                                                        .ThenByDescending(e => e.BirthDate);
            foreach (var e in orderEmployeesNameAgeMethods)
                Console.WriteLine(e);
            Console.WriteLine();


            List<string> cities = new() { "Moscow", "Tula", "Ufa", "Kazan", "Voroneg", "St.Petersburg" };
            var orderCities = cities.OrderBy(c => c);
            foreach (var c in orderCities)
                Console.WriteLine(c);
            Console.WriteLine();

            var orderCitiesLength = cities.OrderBy(c => c, new CityNameLengthComparer());

            foreach (var c in orderCitiesLength)
                Console.WriteLine(c);
            Console.WriteLine();
        }

        public static void LinqSetOperationsExample()
        {
            List<string> students = new() { "Bobby", "Poppy", "Sammy", "Jimmy", "Kenny", "Mikky" };
            SortedSet<string> teachers = new() { "Jenny", "Kenny", "Villy", "Bobby", "Donny", "Henry" };

            var union = students.Concat(teachers); //students.Union(teachers);
            foreach (var n in union)
                Console.Write($"{n} ");
            Console.WriteLine();

            var intersect = students.Intersect(teachers);
            foreach (var n in intersect)
                Console.Write($"{n} ");
            Console.WriteLine();

            var except = students.Except(teachers);
            foreach (var n in except)
                Console.Write($"{n} ");
            Console.WriteLine();

            except = teachers.Except(students);
            foreach (var n in except)
                Console.Write($"{n} ");
            Console.WriteLine();
        }

        public static void LinqAggregateOperationsExample()
        {
            var employees = Employee.ListInit();

            int count = employees.Count();
            Console.WriteLine($"Count of employees = {count}");

            var sumSalary = employees.Sum(e => e.Salary);
            Console.WriteLine($"Sum of salary = {sumSalary}");

            var minSalary = employees.Min(e => e.Salary);
            var youngBirthDate = employees.Min(e => e.BirthDate);
            var maxSalary = employees.Max(e => e.Salary);

            var avgSalary = employees.Average(e => e.Salary);
        }

        public static void LinqSkipTakeExample()
        {
            var employees = Employee.ListInit();
            foreach (var e in employees)
                Console.WriteLine(e);
            Console.WriteLine();

            //var employeesSkip4 = employees.Skip(4).Take(4);
            //foreach (var e in employeesSkip4)
            //    Console.WriteLine(e);
            //Console.WriteLine();

            int pageCount = 5;
            int page = 0;
            int fullCount = employees.Count();

            do
            {
                Console.Clear();

                var pageEmployees = employees.Skip(page * pageCount)
                                             .Take(pageCount);
                foreach (var e in pageEmployees)
                    Console.WriteLine(e);

                page++;
                Console.WriteLine("Press Any Key...\n");
                Console.ReadKey();
            } while (page * pageCount <= fullCount);
        }

        public static void LinkGroupingExample()
        {
            var employees = Employee.ListInit();

            var employeesCompaniesOpers = from e in employees
                                          group e by e.Company;

            foreach (var company in employeesCompaniesOpers)
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company)
                    Console.WriteLine($"\t{employee}");
                Console.WriteLine();
            }
            Console.WriteLine(new String('-', 40) + "\n");

            var employeesCompaniesMethods = employees.GroupBy(e => e.Company);

            foreach (var company in employeesCompaniesMethods)
            {
                Console.WriteLine(company.Key);
                foreach (var employee in company)
                    Console.WriteLine($"\t{employee}");
                Console.WriteLine();
            }

            var companiesCountOpers = from e in employees
                                      group e by e.Company into result
                                      select new
                                      {
                                          Company = result.Key,
                                          Count = result.Count()
                                      };
            foreach (var c in companiesCountOpers)
                Console.WriteLine($"Company: {c.Company}:\t{c.Count}");
            Console.WriteLine();

            var companiesCountMethods = employees
                                        .GroupBy(e => e.Company)
                                        .Select(result => new
                                        {
                                            Company = result.Key,
                                            Count = result.Count()
                                        });
            foreach (var c in companiesCountMethods)
                Console.WriteLine($"Company: {c.Company}:\t{c.Count}");
            Console.WriteLine();


            var companiesInfoOpers = from e in employees
                                     group e by e.Company into result
                                     select new
                                     {
                                         Company = result.Key,
                                         Count = result.Count(),
                                         Employees = from r in result select r,
                                     };

            foreach (var c in companiesInfoOpers)
            {
                Console.WriteLine($"Company: {c.Company}\t[{c.Count}]");
                foreach (var e in c.Employees)
                    Console.WriteLine($"\t{e}");
                Console.WriteLine();
            }
            Console.WriteLine();


            var companiesInfoMethods = employees
                                        .GroupBy(e => e.Company)
                                        .Select(result => new
                                        {
                                            Company = result.Key,
                                            Count = result.Count(),
                                            Employees = result.Select(r => r)
                                        });

            foreach (var c in companiesInfoMethods)
            {
                Console.WriteLine($"Company: {c.Company}\t[{c.Count}]");
                foreach (var e in c.Employees)
                    Console.WriteLine($"\t{e}");
                Console.WriteLine();
            }
        }
    }
}
