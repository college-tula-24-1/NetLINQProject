using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetLINQProject
{
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
    }
}
