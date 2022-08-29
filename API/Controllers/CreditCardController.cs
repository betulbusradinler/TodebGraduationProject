using API.Configuration.Filters.Auth;
using Microsoft.AspNetCore.Mvc;
using Bussines.Abstract;
using Microsoft.AspNetCore.Authorization;
using Models.Document;
using Models.Entities;
using MongoDB.Bson;
using API.Configuration.Filters.Logs;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardController : ControllerBase
    {
        private readonly ICreditCardService _service;

        public CreditCardController(ICreditCardService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        [Permission(Permission.CreditCardGetAll)]
        public IActionResult GetAll()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

      
        [HttpGet("GetById")]
        [Permission(Permission.CreditCardGetById)]
        public CreditCard GetById(string id)
        {

            return _service.Get(new ObjectId(id));
        }


        [HttpPost]
        [Permission(Permission.CreditCardPost)]
        [LogFilter]
        public IActionResult Post(CreditCard request)
        {
            _service.Add(request);
            return Ok();
        }


        [HttpPut]
        [Permission(Permission.CreditCardGetPut)]
        public IActionResult Put(CreditCard request)
        {
            _service.Update(request);
            return Ok();
        }

       
        [HttpDelete]
        [Permission(Permission.CreditCardDelete)]
        public IActionResult Delete(ObjectId id)
        {
            _service.Delete(id);
            return Ok();
        }

    }
}
