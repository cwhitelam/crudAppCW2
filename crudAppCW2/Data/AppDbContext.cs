using System.Collections;
using crudAppCW2.Models;
using Microsoft.EntityFrameworkCore;

namespace crudAppCW2.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options, DbSet<User> users, IEnumerable roles) : base(options)
    {
        Users = users;
        Roles = roles;
    }

    public AppDbContext()
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (optionsBuilder.IsConfigured) return;
        optionsBuilder.UseSqlite("Data Source=Data/crudAppDb.sqlite");
    }

    private DbSet<User> Users { get; set; }
    private IEnumerable Roles { get; set; }
}