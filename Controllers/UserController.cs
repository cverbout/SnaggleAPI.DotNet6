using Microsoft.AspNetCore.Mvc;
using SnaggleAPI.Models;
using System.Security.Cryptography;

namespace SnaggleAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly DataContext _context;

        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("ViewUsers")]
        public async Task<ActionResult<User>> Get()
        {
            return Ok(await _context.Users.Include("Projects").ToListAsync());
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if(_context.Users.Any(u => u.Username == request.UserName))
            {
                return BadRequest("Username Taken");
            }

            CreatePasswordHash(request.Password, 
                out byte[] passwordHash,
                out byte[] passwordSalt);

            var user = new User
            {
                Username = request.UserName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok("User created!");
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
