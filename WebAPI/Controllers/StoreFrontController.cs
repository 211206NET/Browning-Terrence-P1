using Microsoft.AspNetCore.Mvc;
using Models;
using StoreBL;
//using CustomExceptions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreFrontController : ControllerBase
    {
        private IBL _bl;
        public StoreFrontController(IBL bl)
        {
            _bl = bl;
        }
        // GET: api/<StoreFrontController>
        [HttpGet("GetAllStores")]
        public List<Store> Get()
        {
            return _bl.GetAllStores();
        }

        //GET api/<StoreFrontController>/5
        [HttpGet("GetStoreById{id}")]
        public ActionResult<Store> Get(int id)
        {
            Store foundSto = _bl.GetStoreById(id);
            if (foundSto.Id != 0)
            {
                return Ok(foundSto);
            }
            else
            {
                return NoContent();
            }
        }

        // POST api/<StoreFrontController>
        [HttpPost("CreateAStore")]
        public ActionResult Post([FromBody] Store storeToAdd)
        {
            try
            {
                _bl.AddStore(storeToAdd);
                return Created("Successfully added", storeToAdd);
            }
            catch (DuplicateRecordException ex)
            {
                return Conflict(ex.Message);
            }
        }

        //// PUT api/<StoreFrontController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<StoreFrontController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

    }

}
