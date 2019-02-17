using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
    public class Project : IProject
    {
        readonly CrExtContext _context;
        public Project(CrExtContext context)
        {
            _context = context;
        }
        public async Task Create(CreateProjectDto projectDto)
        {
            await _context.Projects.AddAsync(new Projects
            {
                Name = projectDto.Name,
                Description = projectDto.Description,
                OrganisationId = projectDto.OrganisationId
            });
        }
        public async Task<bool> Find(int projectId)
        {
            if ((await _context.Projects.FindAsync(projectId)) != null)
            {
                return true;
            }
            return false;
        }
        public async Task<Projects> Get(int projectId)
        {
            return await _context.Projects.FindAsync(projectId);
        }
        public async Task Delete(int projectId)
        {
          await Task.Run(() => _context.Projects.Remove(_context.Projects.Find(projectId)));
        }

        public async Task<IEnumerable<Projects>> List()
        {

            return await Task.Run(() => _context.Projects.ToList());
        }

        public async Task<bool> OrganisationHasProject(int organisationId)
        {
            var org = await Task.Run(()=> _context.Projects.Any(a => a.OrganisationId == organisationId));
          return  (org) ? true:false;
          
        }

        public async Task<IEnumerable<Projects>> OrganisationProjects(int organisationId)
        {
            return await Task.Run(() => _context.Projects.Where(a => a.OrganisationId == organisationId).ToList());
        }

        public  async Task<bool> Save()
        {
              return ((await _context.SaveChangesAsync()) >= 0);
        }

        public async Task Update(int projectId, string name, string description)
        {
            var project = await _context.Projects.FindAsync(projectId);
            if (project != null)
            {
                project.Description = description;
                project.Name = name;
                _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }
    }
}
