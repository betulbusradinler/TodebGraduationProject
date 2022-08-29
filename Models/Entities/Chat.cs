using System;
using System.ComponentModel.DataAnnotations;

namespace Models.Entities
{
    public class Chat
    {
        [Key]
        public int Id { get; set; } 
        public string Subject { get; set; }     //  Mesajın konusu hakkında bilgi
        public string Content { get; set; }     //  Mesajın içeriği hakkında bilgi
        public string ReciverMail { get; set; } //  Alıcı Mail Adres
        public string SenderMail { get; set; }  //  Gönderici Mail Adres
        public DateTime Created { get; set; } = DateTime.Now;
    }
}
