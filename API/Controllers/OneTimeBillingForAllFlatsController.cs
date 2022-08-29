using Business.Abstract;
using DTO.UtilityBill;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OneTimeBillingForAllFlatsController : ControllerBase
    {
        private IOneTimeBillingForAllFlatsService _utilityBillService;
        public OneTimeBillingForAllFlatsController(IOneTimeBillingForAllFlatsService utilityBillService)
        {
            _utilityBillService = utilityBillService;
        }
        [HttpPost]
        public IActionResult Post(CreateUtilityBillRequestForAllFlats request)
        {
            var response = _utilityBillService.Register(request);
            return Ok(response);
        }
    }
}
