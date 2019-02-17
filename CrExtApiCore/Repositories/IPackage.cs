using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using Entities;
namespace CrExtApiCore.Repositories
{
   public interface IPackageAsync
    {
        Task Create(PackageDto package);
        Task AddRole(int packageId, int RoleId);
        Task RemoveRole(int packageId, int  RoleId);
        Task<bool> HasRole(int packageId, int roleId);

        Task<IEnumerable<PackagePRoles>> PackageRoles(int packageId);
        Task<IEnumerable<PRole>> GetRoles();
        Task<IEnumerable<string>> GetRoleNames(int packageId);
        Task<IEnumerable<Packages>>List();
        Task Delete(int packageId);
        Task<bool> Find(int packageId);
        Task<Packages> Get(int packageId);
        Task<bool> Save();
    }
}
