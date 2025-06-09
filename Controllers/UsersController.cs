using Microsoft.AspNetCore.Mvc;
using MigrationDemo.Data;
using MigrationDemo.Models;

namespace MigrationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUser([FromQuery] int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
