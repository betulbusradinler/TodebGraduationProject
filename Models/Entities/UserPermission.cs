using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class UserPermission
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Permission Permission { get; set; } 
    }
}
