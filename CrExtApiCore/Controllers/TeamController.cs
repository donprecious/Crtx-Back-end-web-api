using System.Threading.Tasks;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Cors;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Team")]
    [EnableCors("AllowOrigin")]
    public class TeamController : Controller
    {
        private readonly ITeam _team;
        public TeamController(ITeam team)
        {
            _team = team;
        }

        [HttpGet("{id}", Name ="GetTeam")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _team.Find(id)) return NotFound();
            var team = await _team.Get(id);
            return Ok(team);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateTeamDto teamDto)
        {
            if (teamDto == null) return NotFound();
            if (ModelState.IsValid)
            {
                var mappedTeam = Mapper.Map<Teams>(teamDto);

                await _team.Create(teamDto);
                //
                if (!await _team.Save())
                {
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }
                var createdUser = Mapper.Map<TeamDto>(mappedTeam);
                return CreatedAtRoute("GetTeam", new { id = createdUser.Id }, createdUser);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
            var teams = await _team.List();
            return Ok(teams);
        }
        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetProjectTeam(int id)
        {
            var teams = await _team.TeamProjects(id);
            return Ok(teams);
        }
    }
}