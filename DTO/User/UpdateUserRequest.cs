﻿using Models.Entities;
using System.Collections.Generic;

namespace DTO.User
{
    public class UpdateUserRequest
    {
        // Kullanıcı güncellemek için gelen request isteğini bu dto türünden alacağız.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string No { get; set; }
        public string Email { get; set; }
        public string VehicleNo { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
        public IEnumerable<Permission> UserPermissions { get; set; }

    }
}
