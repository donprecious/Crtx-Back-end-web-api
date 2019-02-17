using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
  public  interface IProject
    {
        Task Create(CreateProjectDto projectDto);
        Task Update(int projectId, string name, string description);

        Task Delete(int projectId);
        Task<bool> Find(int projectId);
        Task<Projects> Get(int projectId);

        Task<IEnumerable<Projects>> List();
        Task<bool> OrganisationHasProject(int organisationId);

        Task<IEnumerable<Projects>> OrganisationProjects(int organisationId);
        Task<bool> Save();
    }
}
