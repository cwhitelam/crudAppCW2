using System.ComponentModel.DataAnnotations;

namespace crudAppCW2.Data.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public int? RoleId { get; set; }
    }

}


