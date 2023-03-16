using System.ComponentModel.DataAnnotations;
using crudAppCW2.Models;

namespace crudAppCW2.Data.Models;

public class Department
{
    public int DepartmentId { get; set; }

    [Required] 
    [StringLength(50)] 
    public string? Name { get; set; }
    
    public IEnumerable<User>? Users { get; set; }
}