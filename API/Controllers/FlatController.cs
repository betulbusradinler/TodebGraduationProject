using Business.Abstract;
using DTO.Flat;
using DTO.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    //[Authorize(Roles = "Admin,OwnerShipFloot")]
    [Route("api/[controller]")]
    [ApiController]
    public class FlatController : ControllerBase
    {
        private readonly IFlatService _flatService;

        public FlatController(IFlatService service)
        {
            _flatService = service;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _flatService.GetAll();
            return Ok(data);
        }
        [HttpPost()]
        public IActionResult Post(CreateFlatRegisterRequest request)
        {

            var response = _flatService.Register(request);
            return Ok(response);

        }
        [HttpPut]
        public IActionResult Put(UpdateFlatRequest request)
        {

            var response = _flatService.Update(request);
            return Ok(response);

        }
        [HttpDelete]
        public IActionResult Delete(DeleteFlatRequest request)
        {
            var response = _flatService.Delete(request);
            return Ok(response);
        }
    }
}
