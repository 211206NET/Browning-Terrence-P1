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
        // GET: api/<CustomerController>
        [HttpGet("GetAllCustomers")]
        public List<Customer> Get()
        {    
            return _bl.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("GetCustomerBy{id}")]
        public ActionResult<Customer> Get(int id)
        {
            Customer foundCusto = _bl.GetCustomerById(id);
            if (foundCusto.Id != 0)
            {
                return Ok(foundCusto);
            }
            else
            {
                return NoContent();
            }
        }
            [HttpGet("CustomerLogin")]
        public ActionResult<Customer> CustomerLogin(string Username, string UserPassword)
            {
            bool validcheck = _bl.CustomerLogin(Username, UserPassword);
            Customer selectedCustomer = _bl.GetCustomerUsername(Username);

            if (validcheck == true)
            {
                return Ok(selectedCustomer);
            }
            else
            {
                return Unauthorized("You are Unauthorized");
            }

            }
        
                // PUT api/<CustomerController>/5
                //[HttpPut("{id}")]
                //public void Put(int id, [FromBody] string value)
                //{
                //}

                // DELETE api/<CustomerController>/5
                //[HttpDelete("{id}")]
                //public void Delete(int id)
            
        }
    }

