using MessageGet.API.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MessageGet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController(GetContext context) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(context.Messages);
        }
    }
}
