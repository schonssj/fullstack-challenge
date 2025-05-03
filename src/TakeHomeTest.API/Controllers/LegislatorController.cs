using Microsoft.AspNetCore.Mvc;
using TakeHomeTest.API.Services;

namespace TakeHomeTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LegislatorController : Controller
    {
        private readonly LegislatorService _legislatorService;
        
        public LegislatorController(LegislatorService legislatorService)
        {
            _legislatorService = legislatorService;
        }

        /// <summary>
        /// Returns all legislators and their votes.
        /// </summary>
        [HttpGet("GetLegislatorsVotes")]
        public IActionResult GetLegislatorsVotes()
        {
            return Ok(_legislatorService.GetLegislatorsVotes().OrderBy(l => l.LegislatorId));
        }
    }
}
