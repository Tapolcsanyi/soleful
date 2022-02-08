using Microsoft.AspNetCore.Mvc;
using Soleful.Models;
using Soleful.Repositories;
using System;
using System.Security.Claims;

namespace Soleful.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            user.UserTypeId = 2;
            user.CreateDateTime = DateTime.Now;
            _userRepository.Add(user);
            return CreatedAtAction(
                nameof(GetUser),
                new { firebaseUserId = user.FirebaseUserId },
                user);
        }

        [HttpGet("loggedUser")]
        public IActionResult GetLoggedInUser()
        {
            var currentUser = GetCurrentUserProfile();
            int userId = currentUser.Id;
            int id = userId;
            return Ok(_userRepository.GetUserById(id));
        }

        [HttpGet("{firebaseUserId}")]
        public IActionResult GetUser(string firebaseUserId)
        {
            return Ok(_userRepository.GetByFirebaseUserId(firebaseUserId));
        }

        [HttpGet("DoesUserExist/{firebaseUserId}")]
        public IActionResult DoesUserExist(string firebaseUserId)
        {
            var user = _userRepository.GetByFirebaseUserId(firebaseUserId);
            if (user == null)
            {
                return NotFound();
            }
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userRepository.GetAll());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userRepository.GetUserById(id));
        }
        private User GetCurrentUserProfile()
        {
            var firebaseUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return _userRepository.GetByFirebaseUserId(firebaseUserId);
        }
    }
}
