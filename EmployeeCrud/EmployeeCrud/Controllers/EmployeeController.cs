using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeCrud;

public class EmployeeController : Controller
{   
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context) {
        this._context = context;
    }

    
    public async Task<IActionResult> Index()
    {   
        Task<List<Employee>> employees = _context.employees.ToListAsync();
        return View(await employees);
    }

    [HttpGet]
    public IActionResult Add(){
        Employee employee = new Employee();
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Add([Bind("Id,Name,Department")] Employee employee){
        if (ModelState.IsValid)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }
}