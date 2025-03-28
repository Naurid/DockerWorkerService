using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageGet.API.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
    }
}
