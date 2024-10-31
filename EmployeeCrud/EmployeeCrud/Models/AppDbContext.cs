using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Models;

public class AppDbContext : DbContext
{
    public DbSet<Employee> employees {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
    }
}