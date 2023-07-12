using FintessBackendAPI.Data;
using FintessBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FintessBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly FitnessAppDbContext _dbContext;

        public UserController(FitnessAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Users.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _dbContext.Users.Find(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            // Validate the user input

            // Store the user in the database
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Ok("User registered successfully.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] User user)
        {
            if (user == null || user.Id != id)
            {
                return BadRequest();
            }

            var existingUser = _dbContext.Users.Find(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            existingUser.Username = user.Username;
            existingUser.Password = user.Password;

            _dbContext.Users.Update(existingUser);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingUser = _dbContext.Users.Find(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _dbContext.Users.Remove(existingUser);

            return NoContent();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            var regUser = _dbContext.Users.Where(u => u.Username == user.Username).FirstOrDefault();
            
            if (regUser != null)
            {
                if (regUser.Password == user.Password)
                {
                    _dbContext.LoggedUsers.Add(regUser);
                    return Ok($"User {user.Username} signed in.");
                }
                else
                {
                    return BadRequest("Wrong password!");
                }
            }
            else
            {
                return BadRequest("User doesn't exist.");
            }
        }
    }
}
