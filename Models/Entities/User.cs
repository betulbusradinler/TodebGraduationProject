using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string No { get; set; }
        public string Email { get; set; }
        public string VehicleNo { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }

        public Flat Flat { get; set; }
        public UserRole Role { get; set; }
        public UserPassword Password { get; set; }   // User tablosu ile user password tablosu arasında one-to-one ilişki var

    }
}
