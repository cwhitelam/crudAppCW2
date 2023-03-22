namespace crudAppCW2.Data.Models
{
    public class NotificationRole
    {
        public int NotificationRoleId { get; set; }
        public int NotificationId { get; set; }
        public int? RoleId { get; set; }
        public Notification? Notification { get; set; }
        public Role? Role { get; set; }
    }
}