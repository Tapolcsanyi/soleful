using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Soleful.Repositories;
using Soleful.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soleful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListSneakerController : ControllerBase
    {
        private readonly IListSneakerRepository _listSneakerRepository;
        public ListSneakerController(IListSneakerRepository listSneakerRepository)
        {
            _listSneakerRepository = listSneakerRepository;
        }
        // GET: api/<ListSneakerController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_listSneakerRepository.GetAll());
        }

        // GET api/<ListSneakerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_listSneakerRepository.GetListSneakerByListId(id));
        }

        // POST api/<ListSneakerController>
        [HttpPost]
        public IActionResult AddListSneaker(ListSneaker listSneaker)
        {
            _listSneakerRepository.Add(listSneaker);
            return CreatedAtAction("Get", new { id = listSneaker.Id }, listSneaker);
        }

        // PUT api/<ListSneakerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ListSneakerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _listSneakerRepository.Delete(id);
            return NoContent();
        }
    }
}
