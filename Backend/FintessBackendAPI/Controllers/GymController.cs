using FintessBackendAPI.Models;
using FintessBackendAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FintessBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : ControllerBase
    {
        readonly IGymRepository _appRepository;
        public GymController(IGymRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        public ActionResult<List<Gym>> GetAll()
        {
            return Ok(_appRepository.GetGyms());
        }
    }
}
