using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class UserPassword
    {
        [Key]
        public int Id { get; set; }
         
        public int UserId { get; set; }     // User passwordün hangi kullanıcıya ait olduğunu bilmem lazım
       
        [ForeignKey("UserId")]
        public User User { get; set; }  // Bu kez nesne olaraktan hangi User kullanıcısına ait olduğunu bilmem lazım
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }

    }
}
