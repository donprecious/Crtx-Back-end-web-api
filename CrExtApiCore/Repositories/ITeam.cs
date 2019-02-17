using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using Entities;
namespace CrExtApiCore.Repositories
{

   public interface ITeam
    {
        Task Create(CreateTeamDto team );
        Task Delete(int teamId);
        Task<Teams> Get(int teamId);
        Task<IEnumerable<Teams>> List();
        Task Update(string name, string description, int projectId, int teamId);
        Task<bool> Find(int teamId);
        Task<IEnumerable<Projects>> TeamProjects(int projectId);
        Task<bool> TeamHasProject(int projectId, int teamId);

       
        Task<bool> Save();



    }
}
