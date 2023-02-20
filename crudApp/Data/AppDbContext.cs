using System.Collections;
using crudApp.Models;
using Microsoft.EntityFrameworkCore;

namespace crudApp.Data
{ 
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public IEnumerable Roles { get; set; }
    }
}