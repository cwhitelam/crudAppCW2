using crudAppCW2.Models;

namespace crudAppCW2.Data.Models;

public class NotificationUser
{
    public int NotificationUserId { get; set; }
    public int NotificationId { get; set; }
    public int UserId { get; set; }
    public Notification? Notification { get; set; }
    public User? User { get; set; }
}