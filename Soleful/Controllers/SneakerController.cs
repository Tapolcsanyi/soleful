using Microsoft.AspNetCore.Mvc;
using Soleful.Repositories;
using Soleful.Models;

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
        public IActionResult Get(int id)
        {
            return Ok(_sneakerRepository.GetSneakerById(id));
        }

        // POST api/<SneakerController>
        [HttpPost]
        public IActionResult AddCollection(Sneaker sneaker)
        {
            _sneakerRepository.Add(sneaker);
            return CreatedAtAction("Get", new { id = sneaker.Id }, sneaker);
        }

        // PUT api/<SneakerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Sneaker sneaker)
        {
            if (id != sneaker.Id)
            {
                return BadRequest();
            }

            _sneakerRepository.Update(sneaker);
            return NoContent();
        }

        // DELETE api/<SneakerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _sneakerRepository.Delete(id);
            return NoContent();
        }
    }
}
