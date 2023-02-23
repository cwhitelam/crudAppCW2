using crudAppCW2.Data.Models;
using crudAppCW2.Models;
using crudAppCW2.Pages;
using Microsoft.EntityFrameworkCore;

namespace crudAppCW2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public AppDbContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlite("Data Source=Data/crudAppDb.sqlite");
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Department> Departments => Set<Department>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Admin" },
            new Department { Id = 2, Name = "Engineering" },
            new Department { Id = 3, Name = "Golf Course" },
            new Department { Id = 4, Name = "Human Resources" },
            new Department { Id = 5, Name = "IT" });

        /*modelBuilder.Entity<Employee>().HasData(
            new Employee { Id = 1, FirstName = "Anna", LastName = "Rockstar", DepartmentId = 2 },
            new Employee { Id = 2, FirstName = "Julia", LastName = "Developer", DepartmentId = 5, IsDeveloper = true },
            new Employee { Id = 3, FirstName = "Thomas", LastName = "Huber", DepartmentId = 5, IsDeveloper = true },
            new Employee { Id = 4, FirstName = "Sara", LastName = "Metroid", DepartmentId = 1 },
            new Employee { Id = 5, FirstName = "Ben", LastName = "Rockstar", DepartmentId = 4 },
            new Employee { Id = 6, FirstName = "Alex", LastName = "Rider", DepartmentId = 3, IsDeveloper = true },
            new Employee { Id = 7, FirstName = "Sophie", LastName = "Ramos", DepartmentId = 5 },
            new Employee { Id = 8, FirstName = "Julien", LastName = "Russell", DepartmentId = 2 },
            new Employee { Id = 9, FirstName = "Yvonne", LastName = "Snider", DepartmentId = 4 },
            new Employee { Id = 10, FirstName = "Jasmin", LastName = "Curtis", DepartmentId = 1, IsDeveloper = true });*/
    }
}