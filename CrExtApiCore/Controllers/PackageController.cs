using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;

namespace CrExtApiCore.Controllers
{
    [Produces("application/json")]
    [EnableCors("AllowOrigin")]
    [Route("api/Package")]
    public class PackageController : Controller
    {
        private readonly IPackageAsync _package;

        public PackageController(IPackageAsync package)
        {
            _package = package;
        }

        [HttpGet("List")]
        public async Task<IActionResult> GetPackages()
        {
            //if (!await _package.Find(id))
            //{
            //    return NotFound();
            //}
            var packages = await _package.List();
            return Ok(packages);
        }

        [HttpGet("{id}", Name ="GetPackage")]
        public async Task<IActionResult> Get(int id)
        {
            if (!await _package.Find(id))
            {
                return NotFound();
            }
            var package = await _package.Get(id);
            return Ok(package);
        }


        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] PackageDto package)
        {
            if (package == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                //Automapper for mapping packageDto to Package Entity
                var mappedPackage = Mapper.Map<Packages>(package);
                //create the package
              await  _package.Create(package);
                //save the package
                if ( !await _package.Save())
                {
                 return StatusCode(500, "Server Error, Unable to process request");
                }
                //mapped packageEntity to PackageDto
                var savedPackage = Mapper.Map<PackageDto>(mappedPackage);
                //return Created Result 

                //ISSUE is with savedPackage.Id, am unable to get generated ID 
                return CreatedAtRoute("GetPackage", new {id = savedPackage.Id}, savedPackage);
            }
            else
            {
                return BadRequest(ModelState);
            }
           
        }

        [HttpGet("GetPackageRole/{id}", Name = "GetPackageRole")]
        public async Task<IActionResult> GetPackageRole(int id)
        {
            if (!await _package.Find(id))
            {
                return NotFound();
            }

            var packageRole = await _package.GetRoleNames(id);
          
            
            return Ok(packageRole);
        }

        [HttpPost("AddToRole")]
        public async Task<IActionResult> CreatePackageToRole([FromBody] PackageRoleDto packageRole)
        {
            if (packageRole == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _package.HasRole(packageRole.PackageId, packageRole.PRoleId)) return BadRequest( "Package belongs to that role");
                //var mappedPackage = Mapper.Map<Packages>(package);
                await _package.AddRole(packageRole.PackageId, packageRole.PRoleId);
                if (!await _package.Save())
                {
                    return StatusCode(500, "Server Error, Unable to process request");
                }

             //   var savedPackage = Mapper.Map<PackageDto>(mappedPackage);
              return CreatedAtRoute("GetPackageRole", new { id = packageRole.PackageId }, packageRole);
            }
            else
            {
                return BadRequest(ModelState);
            }

        }


        [HttpPost("RemoveFromRole")]
        public async Task<IActionResult> CreateRemovePackageFromRole([FromBody] PackageRoleDto packageRole)
        {
            if (packageRole == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (await _package.HasRole(packageRole.PackageId, packageRole.PRoleId))
                {

                    await _package.RemoveRole(packageRole.PackageId, packageRole.PRoleId);
                    if (!await _package.Save())
                    {
                        return StatusCode(500, "Server Error, Unable to process request");
                    }

                    //   var savedPackage = Mapper.Map<PackageDto>(mappedPackage);
                    return Ok("Role Deleted");
                   // return CreatedAtRoute("GetPackageRole", new { id = packageRole.PackageId }, packageRole);
                }
                else
                {
                    return NotFound("Package Does not belongs to that role");
                }
                //var mappedPackage = Mapper.Map<Packages>(package);
                
            }
            else
            {
                return BadRequest(ModelState);
            }

        }

        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var package = await _package.GetRoles();
            return Ok(package);
        }
    }
}