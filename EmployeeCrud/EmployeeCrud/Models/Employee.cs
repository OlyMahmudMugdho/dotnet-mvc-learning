
namespace EmployeeCrud.Models;

public class Employee
{
    public int Id{get;set;}
    public string Name { get; set; }
    public string Department{get;set;}

    public static implicit operator Task<object>(Employee? v)
    {
        throw new NotImplementedException();
    }
}