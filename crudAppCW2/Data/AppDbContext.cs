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
        
        modelBuilder.Entity<Role>().HasData(
            new Role {Id = 1, Name = "Admin" },
            new Role {Id = 2, Name = "User" });

        modelBuilder.Entity<Department>().HasData(
            new Department { Id = 1, Name = "Commercial" },
            new Department { Id = 2, Name = "Golf Course" },
            new Department { Id = 3, Name = "Maintenance" },
            new Department { Id = 4, Name = "IT" },
            new Department { Id = 5, Name = "Admin" });

        modelBuilder.Entity<UserRole>()
            .HasKey(ud => new { ud.UserId, DepartmentId = ud.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne(ud => ud.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ud => ud.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne(ud => ud.Role)
            .WithMany(d => d.UserRoles)
            .HasForeignKey(ud => ud.RoleId);
    }
}