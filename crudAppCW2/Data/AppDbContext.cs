using crudAppCW2.Data.Models;
using crudAppCW2.Models;
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

    public DbSet<User> User => Set<User>();
    public DbSet<Department> Department => Set<Department>();
    public DbSet<UserRole> UserRole => Set<UserRole>();
    public DbSet<Role> Role => Set<Role>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure User entity
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.LastName)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.Email)
            .IsRequired();
        modelBuilder.Entity<User>()
            .Property(u => u.RoleId)
            .IsRequired(false);
        modelBuilder.Entity<User>()
            .Property(u => u.DepartmentId)
            .IsRequired(false);


        // Configure Role entity
        modelBuilder.Entity<Role>()
            .HasKey(r => r.Id);
        modelBuilder.Entity<Role>()
            .Property(r => r.Name)
            .IsRequired();
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "User" }
        );

        // Configure Department entity
        modelBuilder.Entity<Department>()
            .HasKey(d => d.Id);
        modelBuilder.Entity<Department>()
            .Property(d => d.Name)
            .IsRequired();
        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Admin" },
            new Department { Id = 2, Name = "Commercial" },
            new Department { Id = 3, Name = "Engineering" },
            new Department { Id = 4, Name = "Fabrication" },
            new Department { Id = 5, Name = "Golf Course" },
            new Department { Id = 6, Name = "Human Resources" },
            new Department { Id = 7, Name = "IT" },
            new Department { Id = 8, Name = "Maintenance" },
            new Department { Id = 9, Name = "Sales" },
            new Department { Id = 10, Name = "Superior Walls" }
        );

        // Configure UserRole entity
        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);
    }
}