using API.Configuration.Filters.Auth;
using Business.Abstract;
using DTO.UtilityBillType;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;

namespace API.Controllers
{
    [Authorize]
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
        [Permission(Permission.UtilityBillTypeControllerPost)]
        public IActionResult Post(CreateUtilityBillTypeRegisterRequest request)
        {
            var response = _utilityBillTypeService.Register(request);
            return Ok(response);
        }


        [HttpGet]
        [Permission(Permission.UtilityBillTypeControllerGetAll)]
        public IActionResult Get()
        {
            var data = _utilityBillTypeService.GetAll();
            return Ok(data);
        }


        [HttpPut]
        [Permission(Permission.UtilityBillTypeControllerPut)]
        public IActionResult Put(UpdateUtilityBillTypeRequest request)
        {
            var response = _utilityBillTypeService.Update(request);
            return Ok(response);
        }


        [HttpDelete]
        [Permission(Permission.UtilityBillTypeControllerDelete)]
        public IActionResult Delete(DeleteUtilityBillTypeRequest request)
        {
            var response = _utilityBillTypeService.Delete(request);
            return Ok(response);
        }
    }
}
