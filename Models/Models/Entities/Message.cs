using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class Message
    {
        public string Id { get; set; }

        public string SenderNo { get; set; }
        public string ReceiverNo { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }

    }
}
