using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
namespace CrExtApiCore.Repositories
{
  public  interface IRoleAsync
    {
        Task CreateAsync(string name,string description);
        Task<IEnumerable<Roles>>List();
        Task Delete(string roleId);
        Task<IEnumerable<Roles>> UserRoles(string id);
        Task<IEnumerable<Roles>> UserRolesByEmail(string email);
        Task<bool> Find(string roleid);
        Task<bool> FindByName(string roleName);
        Task<bool> Save();

      //IEnumerable<Roles> UserRolesSync(string id);
    }
}
