using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using CrExtApiCore.Repositories;
using Entities;
namespace CrExtApiCore.Repositories
{
    public class Organisation : IOrganisationAsync
    {
      private  CrExtContext _context;

        public int id { get; set; }

        public Organisation(CrExtContext context)
        {
            _context = context;
        }
        public async Task Create(OrganisationDto org)
        {

            await _context.Organisations.AddAsync(new Organisations
            {
                Name = org.Name,
                Description = org.Description,
                PackageId = org.PackageId,
                UserId = org.UserId
            });
        }

        public async Task Delete(int organisationId)
        {
            var org = await _context.Organisations.FindAsync(organisationId);
            _context.Organisations.Remove(org);

        }

        public async Task<IEnumerable<Organisations>> List()
        {
            return await Task.Run(() => _context.Organisations.ToList());
        }

        public async Task<Organisations> Get(int organisationId)
        {
            return await _context.Organisations.FindAsync(organisationId);
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }

        public async Task<Entities.Organisations> UserOrganisation(string userId)
        {
            var org = await Task.Run(() => _context.Organisations.Where(a => a.UserId == userId).SingleOrDefault());
            return org;
        }

        public async Task<bool> Find(int organisationId)
        {
            if ((await _context.Organisations.FindAsync(organisationId)) != null)
            {
                return true;
            }

            return false;
        }
        
    }
}
