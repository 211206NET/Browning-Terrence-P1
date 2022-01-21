using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IBL _bl;
        

        public OrderController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<OrderController>/CID
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            int CID = 0;
            List<Order> allOrders = _bl.GetAllOrders(CID);
            if (allOrders.Count != 0)
            {
                return Ok(allOrders);
            }
            else
            {
                return NoContent();
            }
        }
    }

    // GET api/<OrderController>/5
    //[HttpGet("{id}")]
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/<OrderController>
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT api/<OrderController>/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE api/<OrderController>/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}
}
