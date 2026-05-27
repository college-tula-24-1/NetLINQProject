using NetLINQProject;
using System.Diagnostics.CodeAnalysis;

/*

LINQ - Luanguage Integrated Query

LINQ to Object
LINQ to XML

LINQ to DataSet
LINQ to Entities

Parallel LINQ

*/

var employees = Employee.ListInit();
ListPrint(employees);

bool result = employees.All(e => DateTime.Now.Year - e.BirthDate.Year >= 30);
Console.WriteLine(result);

result = employees.Any(e => e.Salary < 90000);
Console.WriteLine(result);

Employee tom = new()
{
    Name = "Tommy",
    BirthDate = new DateTime(1995, 10, 24),
    Salary = 120000M,
    Company = new()
    {
        Title = "Yandex",
        City = new()
        {
            Title = "Moscow"
        }
    }
};

result = employees.Contains(tom, new EmployeeComaprer());
Console.WriteLine(result);

var employee = employees.First(e => e.Name == tom.Name);

employee = employees.FirstOrDefault(e => e.Name == tom.Name);
Console.WriteLine(employee);


employee = employees.Last(e => e.Salary > 100000);
employee = employees.LastOrDefault(e => e.BirthDate.Year < 2000);

void ListPrint<T>(IEnumerable<T> collection)
{
    foreach(var item in collection)
        Console.WriteLine(item);
}

class EmployeeComaprer : IEqualityComparer<Employee>
{
    public bool Equals(Employee? x, Employee? y)
    {
        return x.Name == y.Name;
    }

    public int GetHashCode([DisallowNull] Employee obj)
    {
        return HashCode.Combine(obj.Name, obj.Company, obj.BirthDate);
    }
}