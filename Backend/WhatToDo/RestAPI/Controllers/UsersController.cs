using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApi.Models;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly InMemoryDbContext _context;

        public UsersController(InMemoryDbContext context)
        {
            _context = context;
            AddUsers();
        }


        private async void AddUsers()
        {
            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new User("Daniel", "kode1"));
                await _context.SaveChangesAsync();

                _context.Users.Add(new User("Anja", "kode2"));
                await _context.SaveChangesAsync();

                _context.Users.Add(new User("Benjamin", "kode3"));
                await _context.SaveChangesAsync();

                _context.Users.Add(new User("Sarah", "kode4"));
                await _context.SaveChangesAsync();

                _context.Users.Add(new User("Nikolaj", "kode5"));
                await _context.SaveChangesAsync();
            }

        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        //Get: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserId(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet]
        [Route("Login")]
        public async Task<ActionResult> LoginUserAsync(
            [FromQuery] User userRequest)
        {
            var users = await GetUsers();

            if (userRequest != null)
            {
                foreach (var userServer in users.Value)
                {
                    if (userRequest.Username == userServer.Username && userRequest.Password == userServer.Password)
                    {
                        return Accepted();
                    }
                }
            }
            return NotFound();
        }

        // POST: api/Users
       // To protect from overposting attacks, enable the specific properties you want to bind to, for
       // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserId", new { id = user.UserId }, user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
