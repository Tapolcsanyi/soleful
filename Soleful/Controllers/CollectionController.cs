using Microsoft.AspNetCore.Mvc;
using Soleful.Repositories;
using Soleful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Soleful.Repositories;
using Soleful.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Soleful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepository _collectionRepository;
        private readonly IUserRepository _userRepository;
        public CollectionController(ICollectionRepository collectionRepository, IUserRepository userRepository)
        {
            _collectionRepository = collectionRepository;
            _userRepository = userRepository;
        }
        // GET: api/<ListController>
        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUserProfile();
            int userId = currentUser.Id;

            return Ok(_collectionRepository.GetCollectionByUserId(userId));
        }

        // GET api/<ListController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_collectionRepository.GetCollectionById(id));
        }

        // POST api/<ListController>
        [HttpPost]
        public IActionResult AddCollection(Collection collection)
        {
            var currentUser = GetCurrentUserProfile();
            int userId = currentUser.Id;
            collection.UserId = userId;
            _collectionRepository.Add(collection);
            return CreatedAtAction("Get", new { id = collection.Id }, collection);
        }

        // PUT api/<ListController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, Collection collection)
        {
            if (id != collection.Id)
            {
                return BadRequest();
            }

            _collectionRepository.Update(collection);
            return NoContent();
        }

        // DELETE api/<ListController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _collectionRepository.Delete(id);
            return NoContent();
        }
        private User GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
