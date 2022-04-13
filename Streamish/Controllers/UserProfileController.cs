using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Streamish.Models;
using Streamish.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Streamish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IUserProfileRepository _profileRepo;
        public UserProfileController(IUserProfileRepository userProfileRepository)
        {
            _profileRepo = userProfileRepository;
        }

        // GET: api/UserProfile
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_profileRepo.GetAll());
        }

        // GET api/UserProfile/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _profileRepo.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpGet("GetWithVideos/{id}")]
        public IActionResult GetWithVideos(int id)
        {
            var profile = _profileRepo.GetByIdWithVideos(id);
            return Ok(profile);
        }

        // POST api/UserProfile
        [HttpPost]
        public IActionResult Post(UserProfile profile)
        {
            _profileRepo.Add(profile);
            return CreatedAtAction("Get", new { id = profile.Id }, profile);
        }

        // PUT api/UserProfile/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfile profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }
            _profileRepo.Update(profile);
            return NoContent();
        }

        // DELETE api/UserProfile/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _profileRepo.Delete(id);
            return NoContent();
        }
    }
}