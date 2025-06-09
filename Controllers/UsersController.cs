using Microsoft.AspNetCore.Mvc;
using MigrationDemo.Data;
using MigrationDemo.Models;

namespace MigrationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController(ApplicationDbContext context) : ControllerBase
    {
        private readonly ApplicationDbContext _context = context;

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_context.Users.ToList());
        }
    }
}
