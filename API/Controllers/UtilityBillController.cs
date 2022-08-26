using Business.Abstract;
using DTO.UtilityBill;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityBillController : ControllerBase
    {
        private IUtilityBillService _utilityBillService;
        public UtilityBillController(IUtilityBillService utilityBillService)
        {
            _utilityBillService = utilityBillService;
        }
        [HttpPost]
        public IActionResult Post(CreateUtilityBillRequest request)
        {
            var response = _utilityBillService.Register(request);
            return Ok(response);
        }
        //[HttpDelete]
        //public IActionResult Delete(DeleteUtilityBillTypeRequest request)
        //{
        //    var response = _utilityBillTypeService.Delete(request);
        //    return Ok(response);
        //}

        //[HttpPut]
        //public IActionResult Put(UpdateUtilityBillTypeRequest request)
        //{
        //    var response = _utilityBillTypeService.Update(request);
        //    return Ok(response);
        //}
        [HttpGet]
        public IActionResult Get()
        {
            var data = _utilityBillService.GetAll();
            return Ok(data);
        }
    }
}
