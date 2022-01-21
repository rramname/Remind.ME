using BirthdayService.Models;
using BirthdayService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birthdays.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BirthdayController : ControllerBase
    {
        private readonly IBirthdayRepository _repo;

        public BirthdayController(IBirthdayRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetAll()
        {
            return new ObjectResult(await _repo.GetAllUsers());

        }
        [HttpPost]
        public async Task<ActionResult<Birthday>> Create([FromBody] Birthday user)
        {
            await _repo.Create(user);
            return new OkObjectResult(user);
        }
    }
}
