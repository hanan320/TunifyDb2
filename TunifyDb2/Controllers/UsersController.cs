using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TunifyDb2.Data;
using TunifyDb2.Models;
using TunifyDb2.Repositories.Interfaces;

namespace TunifyDb2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUser _user;

        public UsersController(IUser context)
        {
            _user = context;
        }

        // GET: api/Users
        [Route("/user/GetAllUsers")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _user.GetAllUsers());
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _user.GetUserById(id);

            if (user == null)
            {
                return NotFound($"User [{id}] not found.");
            }

            return Ok(user);

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {

            var updatedUser = await _user.UpdateUser(id, user);
            //Check the user
            if (updatedUser == null)
            {
                return NotFound($"User [{id}] not found.");
            }
            return Ok(updatedUser);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var newUser = await _user.CreateUser(user);
            return Ok(newUser);
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            //Check the user
            var user = await _user.GetUserById(id);
            if (user == null)
            {
                return NotFound($"User [{id}] not found");
            }

            await _user.DeleteUser(id);
            return NoContent();
        }

      
    }
}
