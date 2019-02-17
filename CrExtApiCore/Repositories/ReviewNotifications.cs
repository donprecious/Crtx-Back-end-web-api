using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
    public class ReviewNotification : IReviewNotification
    {
        readonly CrExtContext _context;
        public ReviewNotification(CrExtContext context)
        {
            _context = context;
        }
   
        public async Task Create(ReviewNotifications review)
        {
            await _context.ReviewNotifications.AddAsync(review);
        }
        public async Task<bool> Find(int id)
        {
            
            if ((await _context.ReviewNotifications.FindAsync(id)) != null)
            {
                return true;
            }
            return false;
        }
        public async Task<ReviewNotifications> Get(int id)
        {
           
            return await _context.ReviewNotifications.FindAsync(id);
        }
        public async Task Delete(int id)
        {
          await Task.Run(() => _context.ReviewNotifications.Remove(_context.ReviewNotifications.Find(id)));
        }

        public async Task<IEnumerable<ReviewNotifications>> List()
        {

            return await Task.Run(() => _context.ReviewNotifications.ToList());
        }

    

    
        public  async Task<bool> Save()
        {
              return ((await _context.SaveChangesAsync()) >= 0);
        }

       

        //public async Task Update(int projectId, string name, string description)
        //{
        //    var project = await _context.Projects.FindAsync(projectId);
        //    if (project != null)
        //    {
        //        project.Description = description;
        //        project.Name = name;
        //        _context.Entry(project).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        //    }
        //}


    }
}
