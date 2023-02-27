using System.ComponentModel.DataAnnotations;


namespace crudAppCW2.Data.Models;

public class Role
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Please enter a name for the role")]
    public string? Name { get; set; }

    public ICollection<UserRole>? UserRoles { get; set; }
}