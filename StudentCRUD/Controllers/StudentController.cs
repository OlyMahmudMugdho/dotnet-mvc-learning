using Microsoft.AspNetCore.Mvc;
using StudentCRUD.Models;

namespace StudentCRUD;

public class StudentController : Controller {

    private readonly AppDbContext _context;

    public StudentController(AppDbContext context) {
        this._context = context;
    }

    [HttpGet]
    public IActionResult Index(){
        return View();
    }

    [HttpGet]
    public IActionResult Add(){
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Add([Bind("Id, Name, Email, Age")] Student student){
        Console.WriteLine(student.Name);
        await _context.AddAsync(student);
        await _context.SaveChangesAsync();
        return View();
    }
}