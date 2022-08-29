using Models.Entities;
using System;
using System.Collections.Generic;

namespace DTO.User
{
    public class CreateUserRegisterRequest
    {

        // Kullanıcı eklemek için gelen request isteğini bu dto türünden alacağız.
        public string Name { get; set; }
        public string Surname { get; set; }
        public string No { get; set; }
        public string Email { get; set; }
        public string LicensePlate { get; set; }
        public string Phone { get; set; }
        public DateTime Created { get; set; }
        public UserRole Role { get; set; }
        public int FlatId { get; set; }
        public IEnumerable<Permission> UserPermissions { get; set; }
    }
}
