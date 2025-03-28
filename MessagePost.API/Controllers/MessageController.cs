using MessagePost.API.Context;
using MessagePost.API.Entities;
using MessagePost.API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System;

namespace MessagePost.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(PostContext context) : ControllerBase
    {
        [HttpPost("{author}")]
        public IActionResult CreateMessage(string author, [FromBody] MessageEntity message)
        {
            UserEntity? user = context.Users.FirstOrDefault(u => u.FullName == author);
            if (user is null) 
            {
                user = new UserEntity() { FullName = author};
                context.Users.Add(user);
            }

            message.User = user;
            context.Messages.Add(message);
            context.SaveChanges();

            string jsonString = JsonSerializer.Serialize(new {User=user.FullName, Content=message.Content});
            string filePath = $"../shared/Messages/message{message.Id}.json";
            if (!Directory.Exists("../shared/Messages")) Directory.CreateDirectory("../shared/Messages");
            System.IO.File.WriteAllText(filePath, jsonString);

            return Ok();
        }
    }
}
