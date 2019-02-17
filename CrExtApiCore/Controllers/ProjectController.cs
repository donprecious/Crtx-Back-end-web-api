using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrExtApiCore.Repositories;
using CrExtApiCore.Models;
using Entities;
using AutoMapper;
using Microsoft.AspNetCore.Cors;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [Route("api/Project")]
    [EnableCors("AllowOrigin")]
    public class ProjectController : Controller
    {
        private readonly IProject _project;
        private readonly IOrganisationAsync _org;

        public ProjectController(IProject project, IOrganisationAsync org)
        {
            _project = project;
            _org = org;
        }
    
        [HttpGet("list")]
        public async Task<IActionResult> GetList()
        {
         
            var projects = await _project.List();
            return Ok(projects);
        }
        [HttpGet("{id}", Name ="GetProject")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _project.Find(id)) return NotFound("Project not Found");
            var project= await _project.Get(id);
            return Ok(project);
        }

        [HttpGet("organisation/{id}", Name = "GetOrganisationProjects")]
        public async Task<IActionResult> GetOrganisationProjects(int id)
        {
            if (!await _org.Find(id)) return NotFound("Organisation not found");
            var project = await _project.OrganisationProjects(id);
            List<ProjectDto> p = new List<ProjectDto>();
           var mappedProject = Mapper.Map<IEnumerable<ProjectDto>>(project);
       
            return Ok(mappedProject);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProjectDto projectDto)
        {
            if (projectDto == null) return NotFound();
            if (ModelState.IsValid)
            {
                var mapped = Mapper.Map<Projects>(projectDto);

                await _project.Create(projectDto);
                //
                if (!await _project.Save())
                {
                    return StatusCode(500, "Server Error, Something went wrong with our server");
                }
                var created = Mapper.Map<Projects>(mapped);
                return CreatedAtRoute("GetProject", new { id = created.Id }, created);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

    }
}