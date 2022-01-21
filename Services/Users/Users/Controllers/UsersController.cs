using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UsersService.Models;
using UsersService.Repository;
namespace UsersService.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UsersController : ControllerBase
    {
                private readonly IUserRepository _repo;

        public UsersController(IUserRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async  Task<ActionResult<IEnumerable<Users>>> GetAll()
        {
            return new ObjectResult(await _repo.GetAllUsers());

        }
        [HttpPost]
        public async Task<ActionResult<Users>> Create([FromBody] Users user)
        {
            await _repo.Create(user);
            return new OkObjectResult(user);
        }
    }
}
