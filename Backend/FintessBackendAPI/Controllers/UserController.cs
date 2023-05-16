using FintessBackendAPI.Models;
using FintessBackendAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FintessBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserRepository _appRepository;
        public UserController(IUserRepository appRepository)
        {
            _appRepository = appRepository;
        }
        [HttpGet]
        public ActionResult<List<User>> GetAll()
        {
            return Ok(_appRepository.GetUsers());
        }
    }
}
