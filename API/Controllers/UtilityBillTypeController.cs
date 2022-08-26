using Business.Abstract;
using DTO.UtilityBillType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtilityBillTypeController : ControllerBase
    {
        private readonly IUtilityBillTypeService _utilityBillTypeService;
        public UtilityBillTypeController(IUtilityBillTypeService utilityBillTypeService)
        {
            _utilityBillTypeService = utilityBillTypeService;
        }

        [HttpPost]
        public IActionResult Post(CreateUtilityBillTypeRegisterRequest request)
        {
            var response = _utilityBillTypeService.Register(request);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = _utilityBillTypeService.GetAll();
            return Ok(data);
        }


        [HttpPut]
        public IActionResult Put(UpdateUtilityBillTypeRequest request)
        {
            var response = _utilityBillTypeService.Update(request);
            return Ok(response);
        }
        [HttpDelete]
        public IActionResult Delete(DeleteUtilityBillTypeRequest request)
        {
            var response = _utilityBillTypeService.Delete(request);
            return Ok(response);
        }
    }
}
