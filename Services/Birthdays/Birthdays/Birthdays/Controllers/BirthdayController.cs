using BirthdayService.Models;
using BirthdayService.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Birthdays.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BirthdayController : ControllerBase
    {
        private readonly IBirthdayRepository _repo;
        private readonly ILogger<BirthdayController> logger;


        public BirthdayController(IBirthdayRepository repo,ILogger<BirthdayController> _logger)
        {
            _repo = repo;
            logger = _logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Birthday>>> GetAll()
        {
            logger.LogInformation("Geting Birthdays API");
            return new ObjectResult(await _repo.GetAllUsers());

        }
        [HttpPost]
        public async Task<ActionResult<Birthday>> Create([FromBody] Birthday user)
        {
            logger.LogInformation("Geting Birthdays API");
            await _repo.Create(user);
            return new OkObjectResult(user);
        }
    }
}
