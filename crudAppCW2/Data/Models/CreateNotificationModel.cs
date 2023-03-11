namespace crudAppCW2.Models
{
    public class CreateNotificationModel
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
    }
    

}