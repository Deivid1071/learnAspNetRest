using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : ControllerBase
    {
        
        private IBookBusiness _bookBusiness;

        public BookController(IBookBusiness bookBusiness)
        {            
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _bookBusiness.FindById(id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {

            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {

            if (book == null)
            {
                return BadRequest();
            }
            return Ok(_bookBusiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _bookBusiness.DeleteById(id);
            return NoContent();
        }

    }
}
