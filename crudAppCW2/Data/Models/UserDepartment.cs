using crudAppCW2.Models;

namespace crudAppCW2.Data.Models
{
    public class UserDepartment
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
