using System.ComponentModel.DataAnnotations;
using crudAppCW2.Data.Models;

namespace crudAppCW2.Models;

public class User
{
    public int UserId { get; set; }

    [Required(ErrorMessage = "Please enter your first name")]
    public string? FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your last name")]
    public string? LastName { get; set; }

    [Required(ErrorMessage = "Please enter your email")]
    public string? Email { get; set; }

    
    public bool IsRestored { get; set; }
    public bool IsSelected { get; set; }


    public int? DepartmentId { get; set; }
    public Department? Department { get; set; }

    public List<UserRole> UserRoles { get; set; }
    public List<NotificationUser> NotificationUsers { get; set; }


    public string GetCapitalizedString(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            return str;
        }

        str = str.Trim();
        var words = str.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (!string.IsNullOrEmpty(words[i]))
            {
                words[i] = words[i].Substring(0, 1).ToUpper() + words[i].Substring(1);
            }
        }

        return string.Join(' ', words);
    }

}