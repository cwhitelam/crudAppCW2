using crudAppCW2.Data.Models;
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

    public DbSet<Department> Department => Set<Department>();
    public DbSet<User> User => Set<User>();
    public DbSet<Role> Role => Set<Role>();
    public DbSet<UserRole> UserRole => Set<UserRole>();
    public DbSet<Notification> Notification => Set<Notification>();

    public DbSet<NotificationRole> NotificationRole => Set<NotificationRole>();

    public DbSet<NotificationUser> NotificationUser => Set<NotificationUser>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure User entity
        modelBuilder.Entity<User>()
            .HasKey(u => u.UserId);
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
            .Property(u => u.DepartmentId)
            .IsRequired(false);
        modelBuilder.Entity<User>()
            .HasOne<Department>(u => u.Department)
            .WithMany(d => d.Users)
            .HasForeignKey(u => u.DepartmentId)
            .OnDelete(DeleteBehavior.Cascade);


        // Configure Department entity
        modelBuilder.Entity<Department>()
            .HasKey(d => d.DepartmentId);
        modelBuilder.Entity<Department>()
            .Property(d => d.Name)
            .IsRequired();
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, Name = "Administration" },
            new Department { DepartmentId = 2, Name = "Commercial" },
            new Department { DepartmentId = 3, Name = "Engineering" },
            new Department { DepartmentId = 4, Name = "Fabrication" },
            new Department { DepartmentId = 5, Name = "Golf Course" },
            new Department { DepartmentId = 6, Name = "Human Resources" },
            new Department { DepartmentId = 7, Name = "IT" },
            new Department { DepartmentId = 8, Name = "Maintenance" },
            new Department { DepartmentId = 9, Name = "Sales" },
            new Department { DepartmentId = 10, Name = "Superior Walls" }
        );

        // Configure Role entity
        modelBuilder.Entity<Role>()
            .HasKey(r => r.RoleId);
        modelBuilder.Entity<Role>()
            .Property(r => r.Name)
            .IsRequired();
        modelBuilder.Entity<Role>().HasData(
            new Role { RoleId = 1, Name = "Admin" },
            new Role { RoleId = 2, Name = "User" }
        );

        modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        modelBuilder.Entity<UserRole>()
            .HasOne<User>(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId)
            .OnDelete(DeleteBehavior.Cascade);


        modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NotificationRole>()
            .HasKey(nr => new { nr.NotificationId, nr.RoleId });

        modelBuilder.Entity<NotificationRole>()
            .HasOne(nr => nr.Notification)
            .WithMany(n => n.NotificationRoles)
            .HasForeignKey(nr => nr.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NotificationRole>()
            .HasOne(nr => nr.Role)
            .WithMany(r => r.NotificationRoles)
            .HasForeignKey(nr => nr.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NotificationUser>()
            .HasKey(nu => new { nu.NotificationId, nu.UserId });

        modelBuilder.Entity<NotificationUser>()
            .HasOne(nu => nu.Notification)
            .WithMany(n => n.NotificationUsers)
            .HasForeignKey(nu => nu.NotificationId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<NotificationUser>()
            .HasOne(nu => nu.User)
            .WithMany(u => u.NotificationUsers)
            .HasForeignKey(nu => nu.UserId)
            .OnDelete(DeleteBehavior.Cascade);

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