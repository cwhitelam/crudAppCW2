using System.ComponentModel.DataAnnotations;

namespace crudAppCW2.Data.Models;

public class Role
{
    public int RoleId { get; set; }

    [Required(ErrorMessage = "Please enter a name for the role")]
    public string? Name { get; set; }

    public List<User>? Users { get; set; }
    public IEnumerable<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public List<NotificationRole>? NotificationRoles { get; set; }
}