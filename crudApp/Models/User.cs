using System.ComponentModel.DataAnnotations;

namespace crudApp.Models;

public class User
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Please enter your name")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Please enter your email")]
    public string Email { get; set; }

    public string RoleId { get; set; }
}