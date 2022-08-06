using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string No { get; set; }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string NumberPlate { get; set; }

        public UserRole Role { get; set; }
        public UserPassword Password { get; set; }



    }
}
