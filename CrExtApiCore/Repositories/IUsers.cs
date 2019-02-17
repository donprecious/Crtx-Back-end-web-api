using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using Entities;
namespace CrExtApiCore.Repositories
{
   public interface IUserAsync
    {
        
        Task<bool> Create(UserDto user);
        Task AddRole(string UserId, string RoleId);
        Task RemoveRole(string UserId, string RoleId);
        Task<bool> Find(string UserId);
        Task<Users> GetUserByEmail(string email);
        Task<Users> User(string userId);
        Task<IEnumerable<Users>> List();
        Task Delete(string userId);
        Task<bool> Save();
    }
}
