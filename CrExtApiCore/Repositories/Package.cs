using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using Microsoft.EntityFrameworkCore;
using Entities;
using Microsoft.CodeAnalysis.CSharp;

namespace CrExtApiCore.Repositories
{
    public class Package : IPackageAsync
    {
        private CrExtContext _context;

        public Package(CrExtContext  context)
        {
            _context = context;
        }


        public async Task AddRole(int packageId, int RoleId)
        {
            await _context.PackagePRoles.AddAsync(new PackagePRoles
            {
                PackageId = packageId,
                PRoleId = RoleId
            });
        }

  
        public async Task Delete(int packageId)
        {
            var package = await _context.Packages.FindAsync(packageId);
            _context.Packages.Remove(package);
           
        }

        public async Task<bool> Find(int packageId)
        {
            var package =await _context.Packages.FindAsync(packageId);
            return (package!=null)? true:false;
        }

        public async Task<Packages> Get(int packageId)
        {
            return await _context.Packages.FindAsync(packageId);
        }

   

        public async Task<bool> HasRole(int packageId, int roleId)
        {
            var package = await Task.Run(() => _context.PackagePRoles.Where(p => p.PackageId == packageId && p.PRoleId == roleId).SingleOrDefault());
            if (package != null)
            {
                return true;
            }
            return false;
        }



        public async Task<IEnumerable<Packages>> List()
        {
         return await Task.Run(() =>  _context.Packages.ToList());
           
        }

        public async Task<IEnumerable<PackagePRoles>> PackageRoles(int packageId)
        {
           return await Task.Run(() => _context.PackagePRoles.Include(a => a.PRole).Where(a => a.PackageId == packageId).ToList());
       
        }
        public async Task<IEnumerable<string>> GetRoleNames(int packageId)
        {
           var role =  await Task.Run(() => _context.PackagePRoles.Include(a => a.PRole).Where(a => a.PackageId == packageId).ToList());
            if(role != null)
            {
                return role.Select(a => a.PRole.Name).ToList();
            }
            return null;
        }

        public async Task<IEnumerable<PRole>> GetRoles()
        {
            return await Task.Run(() => _context.PRoles.ToList());
        }



        public async Task RemoveRole(int packageId, int RoleId)
        {
            var package = await Task.Run(() => _context.PackagePRoles.Where(a => a.PackageId == packageId && a.PRoleId == RoleId).SingleOrDefault());
            _context.PackagePRoles.Remove(package);
        }

        public async Task Create(PackageDto package)
        {
            await _context.Packages.AddAsync(new Packages
            {
                Name = package.Name,
                Description = package.Description,

            });
        }

        public async Task<bool> Save()
        {
            return ((await _context.SaveChangesAsync()) >= 0);
        }

     
    }
}
