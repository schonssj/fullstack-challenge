using Microsoft.AspNetCore.Mvc;
using TakeHomeTest.API.Services;

namespace TakeHomeTest.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BillController : Controller
    {
        private readonly BillService _billService;

        public BillController(BillService billService)
        {
            _billService = billService;
        }

        /// <summary>
        /// Returns all bills and their votes.
        /// </summary>
        [HttpGet("GetBillsResults")]
        public IActionResult GetBillsResults()
        {
            return Ok(_billService.GetBillsResults().OrderBy(b => b.Id));
        }
    }
}