using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Models;
using Entities;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
namespace CrExtApiCore.Repositories
{
    public class UserAsync : IUserAsync
    {
        private CrExtContext _context;
        private UserManager<Users> _userManager;
        public UserAsync(CrExtContext context, UserManager<Users> userManager )
        {
            _context = context;
            _userManager = userManager;
        }
        //public async Task AddRole(string userId, string roleId)
        //{
        //   return   NotImplementedException();
        // //await _context.UserRoles.AddAsync(new UserRoles
        // //   {
        // //       UserId =userId,
        // //       RoleId = roleId
        // //   });
        //}

        public async Task<bool> Create(UserDto user)
        {
            var mappedUser = Mapper.Map<Users>(user);
            var result = await _userManager.CreateAsync(mappedUser, user.Password);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task Delete(string userId)
        {
            var user = await _context.Users.FindAsync(userId);
            _context.Users.Remove(user);
        }

        public async Task<Users> User(string id)
        {
            var user = await Task.Run(() => _context.Users.SingleOrDefault(a => a.Id.ToString() == id));
            return user;
        }

        public async Task<bool> Find(string userId)
        {
           // Guid id = Guid.Parse(userId);
            
            var user = await Task.Run(()=> _context.Users.SingleOrDefault(a=>a.Id == userId));
            if (user != null)
            {
                return true;
            }
            return false;

        }
        public  async Task<IEnumerable<Users>> List()
        {

            return await Task.Run(() => _context.Users.ToList());
        }
        public async Task<Users> GetUserByEmail(string email)
        {

            return await Task.Run(() => _context.Users.Where(a=>a.Email==email).SingleOrDefault());
        }

        public async Task RemoveRole(string userId, string RoleId)
        {
            var role = await Task.Run(()=> _context.UserRoles.Where(a => a.UserId == userId && a.RoleId == RoleId).SingleOrDefault());
            if (role != null)
            {
                _context.UserRoles.Remove(role);
            }
       
        }

        public async Task<bool> Save()
        {
            var saved = await _context.SaveChangesAsync();
            if (saved >= 0)
            {
               
                return true;
            }

            return false;
        }

        public Task AddRole(string UserId, string RoleId)
        {
            throw new NotImplementedException();
        }
    }
}
