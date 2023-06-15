using Microsoft.AspNetCore.Mvc;
using footballClubMass.Data;
using footballClubMass.Models;
using Microsoft.EntityFrameworkCore;
using footballClubMass.DTO;

namespace footballClubMass.Controllers
{
    [ApiController]
    [Route("contracts")]
    public class ContractController : Controller
    {
        private readonly MyDbContext _dbContext;

        public ContractController(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()

        {
            try
            {
                var playerContracts = _dbContext.playerContracts.ToList();
                return Ok(playerContracts);
            }
            catch (Exception ex)
            {
                // Log the exception or perform any necessary error handling
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while retrieving player contracts.");
            }
        }
        [HttpGet("{playerId}")]
        public IActionResult GetPlayers(int playerId)

        {
            var resources = _dbContext.playerContracts.Where(p => p.playerId == playerId).Select(c => new
            {
                id = c.id,
                endDate = c.endDate,
                salary = c.Salary,
                pages = c.Pages.Select(p => new
                {
                    pageNumber = p.pageNumber,
                    content = p.Content
                }),
                playerName = c.player.Name,
                playerSurname = c.player.Surname
            }).ToList();

            return Ok(resources);
        }

        [HttpPost]
        public IActionResult AddPageToContract([FromBody] PageDto requestData)
        {
            try
            {
                if (Object.ReferenceEquals(requestData, null))
                {
                    return BadRequest("Invalid request body.");
                }

                var playerContract = _dbContext.playerContracts.Select(playerContracts => new
                {
                    countOfPages = playerContracts.Pages.Count,
                    idContract = playerContracts.id
                }).First(p => p.idContract == requestData.contractId);

                var contract = _dbContext.playerContracts.First(p => p.id == requestData.contractId);
                if (contract == null)
                {
                    return NotFound($"Contract with ID {requestData.contractId} not found.");
                }

                try
                {
                    if (string.IsNullOrEmpty(requestData.pageContent))
                    {
                        // requestData.pageContent = null;
                        return BadRequest("Content value can not be null or empty");
                    }
                    contract.Pages.Add(new Page { Content = requestData.pageContent, pageNumber = playerContract.countOfPages + 1 });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
                _dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"An error occurred while adding a page to the contract. Error: {ex.Message}");
            }
        }
    }
}
