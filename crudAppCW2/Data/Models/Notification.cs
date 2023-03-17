using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crudAppCW2.Data.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        
        [Required(ErrorMessage = "Please enter Body")]        
        public string? Description { get; set; }
        [Required(ErrorMessage = "Please enter a Subject")]
        public string? Title { get; set; }
        public bool IsRead { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        public List<NotificationRole>? NotificationRoles { get; set; }
        public List<NotificationUser>? NotificationUsers { get; set; }
    }
}