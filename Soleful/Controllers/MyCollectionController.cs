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
    public class MyCollectionController : ControllerBase
    {
        private readonly IUserSneakerRepository _usersneakerRepository;
        private readonly IUserRepository _userRepository;
        public MyCollectionController(IUserSneakerRepository userSneakerRepository, IUserRepository userRepository)
        {
            _usersneakerRepository = userSneakerRepository;
            _userRepository = userRepository;
        }
        // GET: api/<MyCollection>
        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUserProfile();
            int userId = currentUser.Id;

            return Ok(_usersneakerRepository.GetUserSneakerByUserId(userId));
        }

        // GET api/<MyCollection>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MyCollection>
        [HttpPost]
        public IActionResult AddUserSneaker(UserSneaker sneaker)
        {
            _usersneakerRepository.Add(sneaker);
            return CreatedAtAction("Get", new { id = sneaker.Id }, sneaker);
        }

        // PUT api/<MyCollection>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MyCollection>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        private User GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
