using FintessBackendAPI.Data;
using FintessBackendAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult GetAll()
        {
            return Ok(_dbContext.Gyms.ToList());
        }

        [HttpGet("{Id}")]
        public IActionResult Get(int id)
        {
            var gym = _dbContext.Gyms.FirstOrDefault(x => x.Id == id);

            if (gym == null) { return NotFound(); }
            
            return Ok(gym);
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

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Gym gym)
        {
            var existingGym = _dbContext.Gyms.Find(id);

            if (existingGym == null)
            {
                return NotFound();
            }

            existingGym.Brand = gym.Brand;
            existingGym.Since = gym.Since;

            _dbContext.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var gym = _dbContext.Gyms.Find(id);

            if (gym == null)
            {
                return NotFound();
            }

            _dbContext.Gyms.Remove(gym);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}
