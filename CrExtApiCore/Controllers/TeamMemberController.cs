using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using Entities;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/TeamMember")]
    [EnableCors("AllowOrigin")]
    public class TeamMemberController : Controller
    {
        private ITeamMember _teamMember;
       

     
        public TeamMemberController(ITeamMember teamMember)
        {
            _teamMember = teamMember;
        }
        [HttpGet("{id}", Name = "GetTeamMember")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _teamMember.Find(id)) return NotFound("Team not Found");
            var teamMember = await _teamMember.Get(id);
            return Ok(teamMember);
           
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTeamMemberDto teamMemberDto)
        {
            if (teamMemberDto == null) return NotFound();
            if (ModelState.IsValid)
            {
                var mappedTeam = Mapper.Map<TeamMembers>(teamMemberDto);

                await _teamMember.Create(mappedTeam);
                //
                if (!await _teamMember.Save())
                {
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }
                var created = Mapper.Map<TeamMemberDto>(mappedTeam);
                return CreatedAtRoute("GetTeamMember", new { id = created.Id }, created);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}