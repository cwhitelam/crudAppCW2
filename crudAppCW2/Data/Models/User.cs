using System.ComponentModel.DataAnnotations;
using crudAppCW2.Data.Models;

namespace crudAppCW2.Models;

public class User
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Please enter your first name")]
    public string FirstName { get; set; }
    [Required(ErrorMessage = "Please enter your last name")]
    public string LastName { get; set; }
    [Required(ErrorMessage = "Please enter your email")]
    public string Email { get; set; }
    public int? DepartmentId { get; set; }
    public int? RoleId { get; set; }
    public Department? Department { get; set; }
    public Role? Role { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}