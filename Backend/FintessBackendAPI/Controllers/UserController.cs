using FintessBackendAPI.Data;
using FintessBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<List<User>> GetAll()
        {
            return Ok(_dbContext.Users.ToList());
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            // Validate the user input

            // Store the user in the database
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return Ok("User registered successfully.");
        }
    }
}
