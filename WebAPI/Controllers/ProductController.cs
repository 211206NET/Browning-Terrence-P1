using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IBL _bl;
        public ProductController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public List<Product> Get()
        {
            return _bl.GetAllProducts();
        }

        //GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            Product foundProd = _bl.GetProductById(id);
            if (foundProd.Id != 0)
            {
                return Ok(foundProd);
            }
            else
            {
                return NoContent();
            }
            // POST api/<ProductController>
            //[HttpPost]
            //public void Post([FromBody] string value)
            //{
            //}

            //// PUT api/<ProductController>/5
            //[HttpPut("{id}")]
            //public void Put(int id, [FromBody] string value)
            //{
            //}

            // DELETE api/<ProductController>/5
            //[HttpDelete("{id}")]
            //public void Delete(int id)
            //{
        }
    }
}

