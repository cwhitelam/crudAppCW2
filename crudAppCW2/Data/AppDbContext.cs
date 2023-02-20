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

    private DbSet<User> Users { get; set; }
    private IEnumerable Roles { get; set; }
}