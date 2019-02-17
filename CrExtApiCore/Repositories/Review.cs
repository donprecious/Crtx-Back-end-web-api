using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrExtApiCore.Repositories;
using Entities;
using CrExtApiCore.Models;

namespace CrExtApiCore.Repositories
{
    public class Review : IReview
    {
        readonly CrExtContext _context;
        public Review(CrExtContext context)
        {
            _context = context;
        }
   
        public async Task Create(Reviews review)
        {
            await _context.Reviews.AddAsync(review);
        }
        public async Task<bool> Find(int reviewId)
        {
          
            if ((await _context.Reviews.FindAsync(reviewId)) != null)
            {
                return true;
            }
            return false;
        }
        public async Task<Reviews> Get(int reviewId)
        {
           
            return await _context.Reviews.FindAsync(reviewId);
        }
        public async Task Delete(int reviewId)
        {
          await Task.Run(() => _context.Customers.Remove(_context.Customers.Find(reviewId)));
        }

        public async Task<IEnumerable<Reviews>> List()
        {

            return await Task.Run(() => _context.Reviews.ToList());
        }

        public  async Task<bool> Save()
        {
              return ((await _context.SaveChangesAsync()) >= 0);
        }


    }
}
