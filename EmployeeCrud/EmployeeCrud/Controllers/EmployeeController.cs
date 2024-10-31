using EmployeeCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EmployeeCrud;

public class EmployeeController : Controller
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        this._context = context;
    }


    public async Task<IActionResult> Index()
    {
        Task<List<Employee>> employees = _context.employees.ToListAsync();
        return View(await employees);
    }

    public async Task<IActionResult> Details(int? id)
    {

        if (id == null)
        {
            return NotFound();
        }
        Console.WriteLine("id = " + id);
        Task<Employee> employee = _context.employees.SingleAsync(m => m.Id == id);
        return View(await employee);
    }

    [HttpGet]
    public IActionResult Add()
    {
        Employee employee = new Employee();
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Add([Bind("Id,Name,Department")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            _context.Add(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(employee);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Task<Employee> employee = _context.employees.FirstAsync(m => m.Id == id);

        return View(await employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id,Name,Department")] Employee employee)
    {
        if (!ModelState.IsValid)
        {
            return View(employee);
        }

        try
        {
            _context.employees.Update(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        catch (System.Exception)
        {
            return View(employee);
        }
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = await _context.employees.FindAsync(id);
        _context.employees.Remove(employee);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}