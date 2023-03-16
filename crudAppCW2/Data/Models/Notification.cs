using System.ComponentModel.DataAnnotations.Schema;

namespace crudAppCW2.Data.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string? Body { get; set; }
        public string? Subject { get; set; }
        public bool IsRead { get; set; }
        [NotMapped]
        public bool IsSelected { get; set; }
        
        public DateTime CreatedDateTime { get; set; }
        public List<NotificationRole>? NotificationRoles { get; set; }
        public List<NotificationUser>? NotificationUsers { get; set; }
    }
}