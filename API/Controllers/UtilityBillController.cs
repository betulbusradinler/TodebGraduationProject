using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.UtilityBill;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Authorize]
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
        [Permission(Permission.UtilityBillPost)]
        public IActionResult Post(CreateUtilityBillRequest request)
        {
            var response = _utilityBillService.Register(request);
            return Ok(response);
        }

        
        [HttpGet]
        [Permission(Permission.UtilityBillGetAll)]
        public IActionResult Get()
        {
            var data = _utilityBillService.GetAll();
            return Ok(data);
        }


        [HttpPut]
        [Permission(Permission.UtilityBillPut)]
        public IActionResult Put(UpdateUtilityBillRequest request)
        {
            var response = _utilityBillService.Update(request);
            return Ok(response);
        }

        
        [HttpDelete]
        [Permission(Permission.UtilityBillDelete)]
        public IActionResult Delete(DeleteUtilityBillRequest request)
        {
            var response = _utilityBillService.Delete(request);
            return Ok(response);
        }
    }
}
