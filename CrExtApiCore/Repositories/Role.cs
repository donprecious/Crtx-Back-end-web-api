using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace CrExtApiCore.Repositories
{
    public class Role : IRoleAsync
    {
        private CrExtContext _context;
        private UserManager<Users> _userManager;
        private RoleManager<Roles> _roleManager;

        public Role(CrExtContext context,  UserManager<Users> userManager, RoleManager<Roles> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }
        public async Task CreateAsync(string name, string description)
        {
            await _context.Roles.AddAsync(new Roles
            {
                Name = name,
                Description = description
            });
        }

        public async Task Delete(string roleId)
        {
            var role = await _context.Roles.FindAsync(roleId);
            _context.Remove(role);

        }

        public async Task<bool> Find(string roleid)
        {
            var role = await _context.Roles.FindAsync(roleid);
            if (role != null)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> FindByName(string roleName)
        {
            var role =  await Task.Run(()=> _context.Roles.Where(a => a.Name == roleName).SingleOrDefault());
            if (role != null)
            {
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Roles>> List()
        {
            var roles = await Task.Run(()=> _context.Roles.ToList());
            return roles;
        }

      
          public async Task<bool> Save()
            {
                return ((await _context.SaveChangesAsync()) >= 0);
            }

        public Task<IEnumerable<Roles>> UserRoles(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Roles>> UserRolesByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
