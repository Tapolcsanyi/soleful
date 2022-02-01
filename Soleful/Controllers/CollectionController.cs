using Microsoft.AspNetCore.Mvc;
using Soleful.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soleful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepository;
        public CollectionController(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }
        // GET: api/<ListController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_collectionRepository.GetAll());
        }

        // GET api/<ListController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ListController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ListController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
