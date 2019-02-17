using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;

namespace CrExtApiCore.Repositories
{
    public class TeamMember : ITeamMember
    {
        private CrExtContext _context;
        public TeamMember(CrExtContext context)
        {
            _context = context;
        }

        public async Task Create(TeamMembers teamMember)
        {
          await  _context.TeamMembers.AddAsync(teamMember);

        }

        public async Task<bool> Find(int id)
        {
           
            if ((await _context.TeamMembers.FindAsync(id)) != null)
            {
                return true;
            }
            return false;
        }


        public async Task<IEnumerable<TeamMembers>> List()
        {

            return await Task.Run(() => _context.TeamMembers.ToList());
        }
        public async Task<TeamMembers> Get(int id)
        {
           
            return await _context.TeamMembers.FindAsync(id);
        }
        public Task Delete(string userId)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }
    }
}
