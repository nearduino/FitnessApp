using FintessBackendAPI.Data;
using FintessBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FintessBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        readonly FitnessAppDbContext _dbContext;

        public GymController(FitnessAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult<List<Gym>> GetAll()
        {
            return Ok(_dbContext.Gyms.ToList());
        }

        [HttpPost]
        public IActionResult Post(Gym gym)
        {
            // Validate the gym input

            // Store the gym in the database
            _dbContext.Gyms.Add(gym);
            _dbContext.SaveChanges();

            return Ok("Gym added successfully.");
        }
    }
}
