using MessagePost.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagePost.API.Entities
{
    public class MessageEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserEntity? User { get; set; }
        public string Content { get; set; }
    }
}
