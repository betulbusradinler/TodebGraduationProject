using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; } 
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReciverMail { get; set; }
        public string SenderMail { get; set; }
        public DateTime Created { get; set; }
    }
}
