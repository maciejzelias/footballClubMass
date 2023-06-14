using Microsoft.AspNetCore.Mvc;
using footballClubMass.Data;
using footballClubMass.Models;
using Microsoft.EntityFrameworkCore;

namespace footballClubMass.Controllers
{
    [ApiController]
    [Route("players")]
    public class PlayerController : Controller
    {
        private readonly MyDbContext _dbContext;

        public PlayerController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()

        {
            return Ok();
        }
    }
}
