using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace CrExtApiCore.Repositories
{
    public interface ITeamMember
    {
        Task Create(TeamMembers teamMember);
        Task Delete(string userId);
        Task<bool> Find(int id);
        Task<IEnumerable<TeamMembers>> List();
        Task<TeamMembers> Get(int id);

     
        Task<bool> Save();



    }

   
}
