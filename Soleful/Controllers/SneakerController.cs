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
    public class SneakerController : ControllerBase
    {
        private readonly ISneakerRepository _sneakerRepository;
        public SneakerController(ISneakerRepository sneakerRepository)
        {
            _sneakerRepository = sneakerRepository;
        }
        // GET: api/<SneakerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_sneakerRepository.GetAll());
        }

        // GET api/<SneakerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SneakerController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SneakerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SneakerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
