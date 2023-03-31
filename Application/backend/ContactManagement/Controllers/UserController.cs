using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CoffeeApplication.Model;
using CoffeeApplication.Services;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using CoffeeApplication.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoffeeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<User>> Get()
        {
            return await _userService.Get();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            return await _userService.Get(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            var contact = await _userService.SignIn(user.Email);
            if (contact != null)
            {
                return NotFound();
            }
            await _userService.Create(user);
            return CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }
            await _userService.Update(id, user);
            return NoContent();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var contact = await _userService.Get(id);
            if (contact == null)
            {
                return NotFound();
            }
            await _userService.Delete(contact.Id);
            return NoContent();
        }

        [HttpGet("SignIn/{email}")]
        public async Task<User> SignIn(string email)
        {
            return await _userService.SignIn(email);
        }
    }
}
