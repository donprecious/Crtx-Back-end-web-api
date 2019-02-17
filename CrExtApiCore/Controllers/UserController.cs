using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using Entities;
using Microsoft.AspNetCore.Cors;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    [Route("api/User")]
    public class UserController : Controller
    {
        private readonly IUserAsync _user;
        private readonly IRoleAsync _role;
        public UserController(IUserAsync user, IRoleAsync role)
        {
            _user = user;
            _role = role;
        }

        [HttpGet("List")]
        public async Task<IActionResult> list()
        {          
            var user = await _user.List();
            return Ok(user);
        }

        [HttpGet("{id}",Name ="Get")]
        public async Task<IActionResult> Get(string id)
        {
            if (!await _user.Find(id)) return NotFound(id+"Not Found");
            var user = await _user.User(id);
            return Ok(user);
        }

        [HttpGet("GetUserByEmail/{email}", Name = "GetEmail")]
        public async Task<IActionResult> GetUserByEmail(string email)
        {
            if (email == null) return BadRequest("invalid email");
           
            var user = await _user.GetUserByEmail(email);
            return Ok(user);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] UserDto user)
         {
            if (user == null) return NotFound();
            if (ModelState.IsValid)
            {
                var mappedUser = Mapper.Map<Users>(user);

               ;
                //
                if (! await _user.Create(user))
                {
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }
                var createdUser = Mapper.Map<Users>(mappedUser);

                var route = CreatedAtRoute("Get", new {id = createdUser.Id}, createdUser);
                return route;
            }          
            else
            {
                return BadRequest(ModelState);
            }
        }

        //public async Task<IActionResult> CreateRole([FromBody] role)
        //{

        //}

    }
}