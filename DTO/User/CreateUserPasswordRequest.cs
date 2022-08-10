using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.User
{
    public class CreateUserPasswordRequest
    {

        public int Id { get; set; }

        public int UserId { get; set; }     // User passwordün hangi kullanıcıya ait olduğunu bilmem lazım
        public CreateUserRequest User { get; set; }  // Bu kez nesne olaraktan hangi User kullanıcısına ait olduğunu bilmem lazım
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

    }
}
