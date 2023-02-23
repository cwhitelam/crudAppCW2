using System.ComponentModel.DataAnnotations;
using crudAppCW2.Models;

namespace crudAppCW2.Data.Models;

public class Department
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? Name { get; set; }
    
    public List<User> Users { get; set; }
}