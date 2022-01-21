using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private IBL _bl;
        public CustomerController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Customer>> Get()
        {
            List<Customer> allCustomers = _bl.GetAllCustomers();
            if (allCustomers.Count != 0)
            {
                return Ok(allCustomers);
            }
            else
            {
                return NoContent();
            }
        }
    }

    //GET api/<CustomerController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }*/
}
