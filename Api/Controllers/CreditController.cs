using Api.Application;
using Api.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditService;

        public CreditController(ICreditService creditService) 
        {
            _creditService = creditService;
        }

        [HttpPost]
        public IActionResult GetCredit([FromBody] CreditDTOInput creditDTO)
        {
            try
            {
                var response = _creditService.CalculateTotalValue(creditDTO);
                return Ok(response);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
            
        }
    }
}
