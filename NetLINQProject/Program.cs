using NetLINQProject;

/*

LINQ - Luanguage Integrated Query

LINQ to Object
LINQ to XML

LINQ to DataSet
LINQ to Entities

Parallel LINQ

*/

var employees = Employee.ListInit();

var employeesCompaniesOpers = from e in employees
                              group e by e.Company;

foreach(var company in employeesCompaniesOpers)
{
    Console.WriteLine(company.Key);
    foreach(var employee in company)
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
foreach(var c in companiesCountOpers)
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

foreach(var c in companiesInfoOpers)
{
    Console.WriteLine($"Company: {c.Company}\t[{c.Count}]");
    foreach(var e in c.Employees)
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