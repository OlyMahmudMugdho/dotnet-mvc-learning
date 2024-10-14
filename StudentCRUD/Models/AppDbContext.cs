using Microsoft.EntityFrameworkCore;

namespace StudentCRUD.Models;

public class AppDbContext : DbContext {
    public DbSet<Student> students {get; set;}

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}