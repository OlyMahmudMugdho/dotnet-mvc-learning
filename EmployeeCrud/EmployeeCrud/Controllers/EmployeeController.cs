using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeCrud;

public class EmployeeController : Controller
{   
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context) {
        this._context = context;
    }

    
    public IActionResult Index()
    {
        return View();
    }
}