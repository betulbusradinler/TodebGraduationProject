using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Chat
{
    public class UpdateChatRequest
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public string ReciverMail { get; set; }
        public string SenderMail { get; set; }
    }
}
